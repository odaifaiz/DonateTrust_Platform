using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPF.Model
{
    [Table("rep")]
    public class repM
    {
        [Key]
        [Column("RepId")]
        public string RepId { get; set; }

        [Column("firstname")]
        public string firstname { get; set; }

        [Column("lastname")]
        public string lastname { get; set; }

        [Column("email")]
        public string email { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("phone")]
        public string phone { get; set; }

        [Column("income")]
        public string income { get; set; }

        [Column("location")]
        public string location { get; set; }

        [Column("familymember")]
        public string familymember { get; set; }
    }
}
