using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SPF.Model
{
    [Table("transaction_dataa")]
    public class transaction_dataM
    {
        [Key]
        [Column("TransId")]
        public string TransId { get; set; }

        [Column("DonorId")]
        public string DonorId { get; set; }

        [ForeignKey("DonorId")]
        public virtual donor_dataM Donor { get; set; }

        [Column("programs")]
        public string programs { get; set; }

        [Column("amount")]
        public string amount { get; set; }
        [Column("tx_hash")]
        public string TxHash { get; set; }    

        [Column("chain_timestamp")]
        public DateTime? ChainTimestamp { get; set; }  
    }
}
