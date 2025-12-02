using SPF.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPF.Data
{
    public class donor_dataD
    {
     
        public bool loginCheck(donor_dataM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                   
                    bool exists = ctx.Donors.Any(d => d.DonorId == l.DonorId);
                    if (exists)
                        return false;

                    ctx.Donors.Add(l);
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
                    var list = ctx.Donors.ToList();
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
                    IQueryable<donor_dataM> query = ctx.Donors;

                    if (!string.IsNullOrWhiteSpace(keywords))
                    {
                        query = query.Where(d =>
                            d.firstName.Contains(keywords) ||
                            d.lastName.Contains(keywords) ||
                            d.email.Contains(keywords) ||
                            d.DonorId.Contains(keywords));
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

   
        public bool Update(donor_dataM d)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var existing = ctx.Donors.SingleOrDefault(x => x.DonorId == d.DonorId);
                    if (existing == null)
                        return false;

                    existing.firstName = d.firstName;
                    existing.lastName = d.lastName;
                    existing.email = d.email;
                    existing.phone = d.phone;
                    existing.password = d.password;
                    existing.amount = d.amount;
                    existing.programs = d.programs;

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

     
        public bool Delete(donor_dataM d)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var existing = ctx.Donors.SingleOrDefault(x => x.DonorId == d.DonorId);
                    if (existing == null)
                        return false;

                    ctx.Donors.Remove(existing);
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        
        public bool Insert(donor_dataM d)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var t = new transaction_dataM
                    {
                        TransId = d.DonorId,
                        programs = d.programs,
                        amount = d.amount
                    };

                    ctx.Transactions.Add(t);
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
