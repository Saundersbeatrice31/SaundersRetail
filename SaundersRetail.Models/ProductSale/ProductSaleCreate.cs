using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.ProductSale
{
    public class ProductSaleCreate
    {
        public int ID { get; set; }
        public int SaleID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
