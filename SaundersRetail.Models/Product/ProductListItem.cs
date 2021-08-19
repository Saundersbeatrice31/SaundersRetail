using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Product
{
    public class ProductListItem
    {
        public int ID { get; set; }
        public string ProductName { get; set; }        
        public string Description { get; set; }        
        public decimal RetailPrice { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedDate { get; set; }       
    }
}
