using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace MedicalWebApplicationService.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Email Address")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
