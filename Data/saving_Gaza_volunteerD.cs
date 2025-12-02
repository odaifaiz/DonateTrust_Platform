using SPF.Model;
using System;
using System.Linq;

namespace SPF.Data
{
    internal class saving_Gaza_volunteerD
    {
        public bool loginCheck(saving_Gaza_volunteerM l)
        {
            try
            {
                using (var ctx = new SpfContext())
                {
                    // 1) جدول flood_relief_volunteer
                    bool existsFlood = ctx.FloodReliefVolunteers.Any(v => v.sav_volId == l.sav_volId);
                    if (!existsFlood)
                    {
                        ctx.FloodReliefVolunteers.Add(l);
                    }

                    // 2) جدول volunteer_data
                    bool existsVolunteer = ctx.Volunteers.Any(v => v.VolId == l.sav_volId);
                    if (!existsVolunteer)
                    {
                        var v = new volunteer_dataM
                        {
                            VolId = l.sav_volId,
                            firstName = l.firstname,
                            lastName = l.lastname,
                            email = l.email,
                            password = l.password,
                            phone = l.phone
                        };
                        ctx.Volunteers.Add(v);
                    }

                    // 3) جدول المستخدمين login
                    bool existsUser = ctx.Logins.Any(u => u.username == l.sav_volId);
                    if (!existsUser)
                    {
                        var user = new loginM
                        {
                            username = l.sav_volId,
                            password = l.password,
                            usertype = "Volunteer"
                        };
                        ctx.Logins.Add(user);
                    }

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
