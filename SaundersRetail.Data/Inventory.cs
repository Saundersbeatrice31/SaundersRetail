using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Data
{
    public class Inventory
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Quantity { get; set; }
        public int EndQuantity 
        {
            get
            {
                int endQuantity = 0;
                endQuantity += (Quantity);
                foreach (var item in Products)
                {
                    foreach (var i in item.Products)
                    {
                        endQuantity -= i.Quantity;
                    }

                }
                return endQuantity;
            } 
        }
        [Required]
        public decimal PurchasePrice { get; set; }
        [Required]
        public DateTimeOffset PurchaseDate { get; set; }
        
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
        public virtual ICollection<SaleData> SaleDatas { get; set; } = new List<SaleData>();
    }
}
