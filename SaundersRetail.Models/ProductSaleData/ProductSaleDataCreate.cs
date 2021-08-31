using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.ProductSaleData
{
    public class ProductSaleDataCreate
    {
        public int ID { get; set; }
        public int SDID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
      
    }
}
