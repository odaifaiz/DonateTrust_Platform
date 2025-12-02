using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPF.Model
{
    [Table("tbl")]
    public class tblM
    {
        [Key]
        [Column("cnic")]
        public string cnic { get; set; }
    }
}
