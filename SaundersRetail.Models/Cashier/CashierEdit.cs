using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Cashier
{
    public class CashierEdit
    {
        public int CashierID { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = " Email Address")]
        public string EmailAddress { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
