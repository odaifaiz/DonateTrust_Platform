using SPF.Model;
using System;
using System.Linq;

namespace SPF.Data
{
    internal class education_relief_donorD
    {
        public bool loginCheck(education_relief_donorM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    // 1) جدول education_relief_donor
                    bool existsRelief = ctx.EducationReliefDonors.Any(d => d.ErdId == l.ErdId);
                    if (!existsRelief)
                    {
                        ctx.EducationReliefDonors.Add(l);
                    }

                    // 2) جدول donor_data العام
                    bool existsDonor = ctx.Donors.Any(d => d.DonorId == l.ErdId);
                    if (!existsDonor)
                    {
                        var donor = new donor_dataM
                        {
                            DonorId = l.ErdId,
                            firstName = l.firstname,
                            lastName = l.lastname,
                            email = l.email,
                            password = l.password,
                            phone = l.phone
                        };

                        ctx.Donors.Add(donor);
                    }

                    // 3) جدول المستخدمين login  (هذا الجزء الجديد)
                    bool existsUser = ctx.Logins.Any(u => u.username == l.ErdId);
                    if (!existsUser)
                    {
                        var user = new loginM
                        {
                            username = l.ErdId,      // اسم المستخدم = رقم/معرّف المتبرع
                            password = l.password,   // كلمة المرور كما أدخلها في الفورم
                            usertype = "Donor"       // نوع المستخدم (متبرع)
                        };

                        ctx.Logins.Add(user);
                    }

                    // 4) حفظ كل التغييرات مرة واحدة
                    ctx.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
