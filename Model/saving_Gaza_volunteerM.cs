using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPF.Model
{
    [Table("saving_Gaza_volunteer")]
    public class saving_Gaza_volunteerM
    {
        [Key]
        [Column("sav_volId")]
        public string sav_volId { get; set; }

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
    }
}
