using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;
using System.Xml.Linq;
using MedicalWebApplicationDomain.Enums;

namespace MedicalWebApplicationService.ViewModel
{
    public class UserViewModel
    {

        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Invalid Email Format")]
        [DisplayName("Email Address")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Gender")]
        public Gender Gender { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number, E,g 081-394-90503")]
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [RegularExpression(@"(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[\W])(?!.* ).{6,}", ErrorMessage = "Password must be Alphanumeric and contain at least one special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please enter confirm password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and confirm password does not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
