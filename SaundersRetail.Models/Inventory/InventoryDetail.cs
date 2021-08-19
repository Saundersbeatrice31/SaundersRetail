using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Inventory
{
    public class InventoryDetail
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }
        public int EndQuantity { get; set; }
        public DateTimeOffset PurchaseDate { get; set; }
    }
}
