using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Sale
{
    public class SaleCreate
    {
        public int SaleID { get; set; }
        public DateTimeOffset SaleDate { get; set; }
    }                        
}
