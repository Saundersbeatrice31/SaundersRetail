using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.SaleData
{
    public class SaleDataListItem
    {
        public int SDID { get; set; }
        public Guid SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Tax { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
    }
}
