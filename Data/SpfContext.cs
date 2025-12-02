using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SPF.Model;   // استخدام الكيانات من مشروع BLL

namespace SPF.Data
{
    public class SpfContext : DbContext
    {
        public SpfContext() : base("name=SpfConnection")
        {
            // ينشئ قاعدة البيانات تلقائياً إذا لم تكن موجودة
            Database.SetInitializer(new CreateDatabaseIfNotExists<SpfContext>());
        }

        public DbSet<donor_dataM> Donors { get; set; }
        public DbSet<education_relief_donorM> EducationReliefDonors { get; set; }
        public DbSet<education_relief_volunteerM> EducationReliefVolunteers { get; set; }
        public DbSet<saving_Gaza_donorM> FloodReliefDonors { get; set; }
        public DbSet<saving_Gaza_volunteerM> FloodReliefVolunteers { get; set; }
        public DbSet<loginM> Logins { get; set; }
        public DbSet<repM> Reps { get; set; }
        public DbSet<tblM> Tbls { get; set; }
        public DbSet<transaction_dataM> Transactions { get; set; }
        public DbSet<volunteer_dataM> Volunteers { get; set; }
        public DbSet<volunteer_tblM> VolunteerTbls { get; set; }
        public DbSet<AdminM> Admins{ get; set; }
    }
}
