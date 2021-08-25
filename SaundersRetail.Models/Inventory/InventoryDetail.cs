using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Inventory
{
    public class InventoryDetail
    {
        [Display(Name = "Product ID")]
        public int ProductID { get; set; }

        [Display(Name = "Product Name")]
        public string ProductName { get; set; }

        public int Quantity { get; set; }

        [Display(Name = "Purchase Price")]
        public decimal PurchasePrice { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTimeOffset PurchaseDate { get; set; }
        public int EndQuantity { get; set; }
        
    }
}
