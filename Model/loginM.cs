using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPF.Model
{
    [Table("login")]
    public class loginM
    {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("username")]
        public string username { get; set; }

        [Column("password")]
        public string password { get; set; }

        [Column("usertype")]
        public string usertype { get; set; }   // Admin / Donor / Volunteer
    }
}
