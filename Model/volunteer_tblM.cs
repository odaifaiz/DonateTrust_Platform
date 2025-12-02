using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPF.Model
{
    [Table("volunteer_tbl")]
    public class volunteer_tblM
    {
        [Key]
        [Column("VolId")]
        public string VolId { get; set; }
    }
}
