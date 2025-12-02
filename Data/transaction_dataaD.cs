using SPF.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace SPF.Data
{
    internal class transaction_dataDAL
    {
        // إدخال تبرع جديد
        public bool Insert(transaction_dataM t)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
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

        // عرض كل التبرعات
        public DataTable Select()
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    var list = ctx.Transactions.ToList();
                    return ToDataTable(list);
                }
            }
            catch (Exception)
            {
                return new DataTable();
            }
        }

        // البحث عن تبرعات بالكلمة المفتاحية
        public DataTable Search(string keywords)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    IQueryable<transaction_dataM> query = ctx.Transactions;

                    if (!string.IsNullOrWhiteSpace(keywords))
                    {
                        query = query.Where(t =>
                            t.TransId.Contains(keywords) ||   // لو TransId string
                            t.DonorId.Contains(keywords) ||
                            t.programs.Contains(keywords) ||
                            t.amount.Contains(keywords));
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
