using SPF.Model;
using System;
using System.Linq;

namespace SPF.Data
{
    internal class education_relief_volunteerD
    {
        public bool loginCheck(education_relief_volunteerM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    // 1) جدول education_relief_volunteer
                    bool existsRelief = ctx.EducationReliefVolunteers.Any(v => v.ErvId == l.ErvId);
                    if (!existsRelief)
                    {
                        ctx.EducationReliefVolunteers.Add(l);
                    }

                    // 2) جدول volunteer_data
                    bool existsVolunteer = ctx.Volunteers.Any(v => v.VolId == l.ErvId);
                    if (!existsVolunteer)
                    {
                        var v = new volunteer_dataM
                        {
                            VolId = l.ErvId,
                            firstName = l.firstname,
                            lastName = l.lastname,
                            email = l.email,
                            password = l.password,
                            phone = l.phone
                        };
                        ctx.Volunteers.Add(v);
                    }

                    // 3) جدول المستخدمين login
                    bool existsUser = ctx.Logins.Any(u => u.username == l.ErvId);
                    if (!existsUser)
                    {
                        var user = new loginM
                        {
                            username = l.ErvId,      // اسم المستخدم = رقم/معرف المتطوع
                            password = l.password,   // كلمة المرور كما أدخلها
                            usertype = "Volunteer"   // نوع المستخدم (متطوع)
                        };
                        ctx.Logins.Add(user);
                    }

                    // 4) حفظ التغييرات
                    ctx.SaveChanges();
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
