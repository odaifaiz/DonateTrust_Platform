using SPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SPF.Data
{
    internal class saving_Gaza_donorD
    {
        // التسجيل (اللي كان اسمه loginCheck)
        public bool loginCheck(saving_Gaza_donorM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    // 1) جدول flood_relief_donor
                    bool existsFlood = ctx.FloodReliefDonors.Any(d => d.sav_donorID == l.sav_donorID);
                    if (!existsFlood)
                    {
                        ctx.FloodReliefDonors.Add(l);
                    }

                    // 2) جدول donor_data العام
                    bool existsDonor = ctx.Donors.Any(d => d.DonorId == l.sav_donorID);
                    if (!existsDonor)
                    {
                        var d = new donor_dataM
                        {
                            DonorId = l.sav_donorID,
                            firstName = l.firstname,
                            lastName = l.lastname,
                            email = l.email,
                            password = l.password,
                            phone = l.phone
                        };
                        ctx.Donors.Add(d);
                    }

                    // 3) جدول المستخدمين login
                    bool existsUser = ctx.Logins.Any(u => u.username == l.sav_donorID);
                    if (!existsUser)
                    {
                        var user = new loginM
                        {
                            username = l.sav_donorID,
                            password = l.password,
                            usertype = "Donor"
                        };
                        ctx.Logins.Add(user);
                    }

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        // نفس فكرة SELECT * FROM flood_relief_donor
        public DataTable Select()
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var list = ctx.FloodReliefDonors.ToList();
                    return ToDataTable(list);
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        public DataTable Search(string keywords)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    IQueryable<saving_Gaza_donorM> query = ctx.FloodReliefDonors;

                    if (!string.IsNullOrWhiteSpace(keywords))
                    {
                        query = query.Where(d =>
                            d.sav_donorID.Contains(keywords) ||
                            d.firstname.Contains(keywords) ||
                            d.lastname.Contains(keywords) ||
                            d.email.Contains(keywords) ||
                            d.phone.Contains(keywords));
                    }

                    var list = query.ToList();
                    return ToDataTable(list);
                }
            }
            catch
            {
                return new DataTable();
            }
        }

        private DataTable ToDataTable<T>(IEnumerable<T> data)
        {
            var dt = new DataTable();
            var props = typeof(T).GetProperties();

            foreach (var p in props)
            {
                dt.Columns.Add(p.Name, Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType);
            }

            foreach (var item in data)
            {
                var row = dt.NewRow();
                foreach (var p in props)
                {
                    row[p.Name] = p.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
