using SPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SPF.Data
{
    internal class volunteer_tblD
    {
        // إنشاء مستخدم login من متطوع (مثل ما كان يعمل INSERT INTO tbl_user FROM volunteer_data)
        public bool loginCheck(volunteer_tblM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var volunteer = ctx.Volunteers.SingleOrDefault(v => v.VolId == l.VolId);
                    if (volunteer == null)
                        return false;

                    bool existsLogin = ctx.Logins.Any(x => x.username == volunteer.VolId);
                    if (!existsLogin)
                    {
                        var login = new loginM
                        {
                            username = volunteer.VolId,
                            password = volunteer.password
                        };
                        ctx.Logins.Add(login);
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

        // سنعتبر أن Select يعرض جدول المتطوعين مع البرامج/المهام
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
                            v.programs.Contains(keywords) ||
                            v.task.Contains(keywords));
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
