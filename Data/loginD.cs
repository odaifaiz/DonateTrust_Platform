using SPF.Model;
using System;
using System.Linq;

namespace SPF.Data
{
    internal class loginD
    {
        public bool loginCheck(loginM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    // التحقق من اسم المستخدم + كلمة المرور + نوع المستخدم
                    return ctx.Logins.Any(u =>
                        u.username == l.username &&
                        u.password == l.password &&
                        u.usertype == l.usertype);
                }
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
