using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Data
{
    public class Sale
    {
        [Key]
        public int SaleID { get; set; }
        [Required]
        public Guid CashierID { get; set; }
        [Required]
        public DateTimeOffset SaleDate { get; set; }
        public int Quantity { get; set; }
        [Required]
        public decimal SubTotal
        {
            get
            {
                decimal subTotal = 0;
                foreach (var item in Sales)
                {
                    subTotal += (item.Product.RetailPrice * item.Quantity);

                }
                return subTotal;
            }
        }     
        [Required]
        public decimal Tax
        {
            get
            {
                decimal taxAmount = 0;
                decimal taxRate = 0.07m;                                
                taxAmount += (SubTotal * taxRate);                
                return taxAmount;
            }

        }
        [Required]
        public decimal Total 
        {
            get
            {
             decimal totalAmount = 0;                               
             totalAmount += (SubTotal + Tax);                
             return totalAmount;
            } 
        }

        [ForeignKey(nameof(Cashier))]
        public int? CashID { get; set; }
        public virtual Cashier Cashier { get; set; }

       

        public virtual ICollection<ProductSale> Sales { get; set; } = new List<ProductSale>();
        public virtual ICollection<InventorySale> sale { get; set; } = new List<InventorySale>();

    }
}
