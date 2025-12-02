using SPF.Model;
using System;
using System.Linq;

namespace SPF.Data
{
    internal class tblD
    {
        public bool loginCheck(tblM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    // نبحث عن المتبرع الأساسي لنأخذ الباسوورد منه
                    var donor = ctx.Donors.SingleOrDefault(d => d.DonorId == l.cnic);
                    if (donor == null)
                        return false;

                    // لو المستخدم موجود مسبقاً لا نكرره
                    bool existsLogin = ctx.Logins.Any(x => x.username == donor.DonorId);
                    if (!existsLogin)
                    {
                        var login = new loginM
                        {
                            username = donor.DonorId,
                            password = donor.password
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
    }
}
