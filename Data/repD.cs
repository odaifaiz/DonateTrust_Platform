using SPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SPF.Data
{
    internal class repD
    {
        public bool loginCheck(repM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    bool exists = ctx.Reps.Any(r => r.RepId == l.RepId);
                    if (!exists)
                    {
                        ctx.Reps.Add(l);
                        ctx.SaveChanges();
                    }
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
                    var list = ctx.Reps.ToList();
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
                    IQueryable<repM> query = ctx.Reps;

                    if (!string.IsNullOrWhiteSpace(keywords))
                    {
                        query = query.Where(r =>
                            r.firstname.Contains(keywords) ||
                            r.lastname.Contains(keywords) ||
                            r.email.Contains(keywords) ||
                            r.RepId.Contains(keywords) ||
                            r.location.Contains(keywords));
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
