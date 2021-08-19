using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Sale
{
    public class SaleEdit
    {
        public int SaleID { get; set; }        
        public Guid CashierID { get; set; }       
        public DateTimeOffset SaleDate { get; set; }       
        public decimal SubTotal { get; set; }       
        public decimal Tax { get; set; }        
        public decimal Total { get; set; }
    }
}
