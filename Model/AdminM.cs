using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPF.Model
{
    [Table("admins")]
    public class AdminM
    {
         // اسم الجدول في SQL
        
             [Key]
            [Column("AdminId")]
            public int AdminId { get; set; }   // مفتاح أساسي

            [Column("username")]
            public string Username { get; set; }

            [Column("password")]
            public string Password { get; set; }

        }
    }
