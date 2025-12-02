using SPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SPF.Data
{
    internal class volunteer_dataD
    {
        // تسجيل متطوع جديد
        public bool loginCheck(volunteer_dataM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    bool exists = ctx.Volunteers.Any(v => v.VolId == l.VolId);
                    if (exists)
                        return false;

                    ctx.Volunteers.Add(l);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public DataTable Select()
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var list = ctx.Volunteers.ToList();
                    return ToDataTable(list);
                }
            }
            catch (Exception)
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
                    IQueryable<volunteer_dataM> query = ctx.Volunteers;

                    if (!string.IsNullOrWhiteSpace(keywords))
                    {
                        query = query.Where(v =>
                            v.firstName.Contains(keywords) ||
                            v.lastName.Contains(keywords) ||
                            v.email.Contains(keywords) ||
                            v.VolId.Contains(keywords));
                    }

                    var list = query.ToList();
                    return ToDataTable(list);
                }
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        public bool Update(volunteer_dataM d)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var existing = ctx.Volunteers.SingleOrDefault(v => v.VolId == d.VolId);
                    if (existing == null)
                        return false;

                    existing.firstName = d.firstName;
                    existing.lastName = d.lastName;
                    existing.email = d.email;
                    existing.phone = d.phone;
                    existing.password = d.password;
                    existing.amount = d.amount;
                    existing.programs = d.programs;
                    existing.task = d.task;

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(volunteer_dataM d)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var existing = ctx.Volunteers.SingleOrDefault(v => v.VolId == d.VolId);
                    if (existing == null)
                        return false;

                    ctx.Volunteers.Remove(existing);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // في الكود القديم كان يدخل في جدول volunteer_task، هنا سنعتبر أن task/programs تُخزن في نفس جدول volunteer_data
        public bool Insert(volunteer_dataM d)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var existing = ctx.Volunteers.SingleOrDefault(v => v.VolId == d.VolId);
                    if (existing == null)
                        return false;

                    existing.programs = d.programs;
                    existing.task = d.task;

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
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
