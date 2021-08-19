using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Cashier
{
    public class CashierDetail
    {
        public int CashierID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
