using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPF.Model
{
    [Table("volunteer_data")]
    public class volunteer_dataM
    {
        [Key]
        [Column("VolId")]
        public string VolId { get; set; }

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

        [Column("task")]
        public string task { get; set; }
    }
}
