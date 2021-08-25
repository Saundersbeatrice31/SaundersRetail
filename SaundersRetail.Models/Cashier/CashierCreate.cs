using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaundersRetail.Models.Cashier
{
    public class CashierCreate
    {
        [Display (Name = "Cashier ID")]
        public int CashierID { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You must give a first name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required (ErrorMessage ="You must give a last name.")]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = " Email Address")]
        public string EmailAddress { get; set; }

        [Display(Name = "Date")]
        public DateTimeOffset CreatedDate { get; set; }
    }
}
