using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Data
{
    public class SaleData
    {
        [Key]
        public int SDID { get; set; } 
        
        [Required]
        public int ProductID { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public decimal Tax 
        {
            get
            {
                decimal taxAmount = 0;
                decimal taxRate = 0.07m;                
                    taxAmount += (PurchasePrice * taxRate);                
                return taxAmount;
            }
        }
        public decimal TotalPurchasePrice
        {
            get
            {
                decimal totalAmount = 0;
                foreach (var item in Purchases)
                {
                    totalAmount += (PurchasePrice + Tax);
                }
                return totalAmount;
            }
        }
        public DateTimeOffset PurchaseDate { get; set; }

        public decimal GrossProfit
        {
            get
            {
                decimal totalProfit = 0;
                foreach (var item in Purchases)
                {
                    totalProfit += (TotalPurchasePrice - item.Product.RetailPrice);
                }
                return totalProfit;
            }
        }

        [ForeignKey(nameof(Inventory))]
        public int? ID { get; set; }
        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<ProductSaleData> Purchases { get; set; } = new List<ProductSaleData>();

    }
}
