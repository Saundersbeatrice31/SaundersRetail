using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Data
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [StringLength(10000), Display(Name = "Product Description"), DataType(DataType.MultilineText)]
        public string Description { get; set; }
        public string ImagePath { get; set; }
        [Required]
        [Display(Name ="Price")]
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }        
        public bool IsTaxable { get; set; } = true;
        public DateTimeOffset CreatedDate { get; set; }
        public DateTimeOffset? LastModified { get; set; }

        [ForeignKey(nameof(Inventory))]
        public int? ProductID { get; set; }
        public virtual Inventory Inventory { get; set; }

        public virtual ICollection<ProductSale> Products { get; set; } = new List<ProductSale>();
        public virtual ICollection<ProductSaleData> Sales { get; set; } = new List<ProductSaleData>();
    }
}
