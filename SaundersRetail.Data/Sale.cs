using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Data
{
    public class Sale
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public int CashierID { get; set; }
        [Required]
        public DateTimeOffset SaleDate { get; set; }
        [Required]
        public decimal SubTotal { get; set; }
        [Required]
        public decimal Tax { get; set; }
        [Required]
        public decimal Total { get; set; }
    }
}
