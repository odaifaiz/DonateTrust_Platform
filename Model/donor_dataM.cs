using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPF.Model
{
    [Table("donor_data")] // اسم الجدول في قاعدة البيانات (عدّله حسب اسم جدولك الحقيقي)
    public class donor_dataM
    {
        [Key]
        [Column("DonorId")]
        public string DonorId { get; set; }

        [Column("firstName")]
        public string firstName { get; set; }

        [Column("lastName")]
        public string lastName { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("phone")]
        public string phone { get; set; }

        [Column("amount")]
        public string amount { get; set; }

        [Column("programs")]
        public string programs { get; set; }

        public virtual ICollection<transaction_dataM> Transactions { get; set; }
    }
}
