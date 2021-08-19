using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Sale
{
   public class SaleDetail
    {
        public int SaleID { get; set; }
        public Guid CashierID { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset SaleDate { get; set; }
        
        public decimal SubTotal { get; set; }
        
        public decimal Tax { get; set; }
        
        public decimal Total { get; set; }
    }
}
