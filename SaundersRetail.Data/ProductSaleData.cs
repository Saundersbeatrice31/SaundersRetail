using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Data
{
    public class ProductSaleData
    {
        [Key, Column(Order = 0)]
        [ForeignKey(nameof(Product))]
        public int? ID { get; set; }
        public virtual Product Product { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey(nameof(SaleData))]
        public int? SDID { get; set; }
        public virtual SaleData SaleData { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }

        
    }
}
