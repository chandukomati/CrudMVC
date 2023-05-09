using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DemoCrud3.Models
{
    public class CustomClass
    {
        public partial class clsCustomer
        {
            public int Id { get; set; }
            [Required]
            public string CustomerName { get; set; }
            [Required]
            public string ProductName { get; set; }
            [Required]
            public string ProductCode { get; set; }
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Phone Number")]
            [Required(ErrorMessage = "Phone Number Required!")]
            [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
            public string Mobileno { get; set; }
            [Required]
            public string City { get; set; }
        }
    }
}