using MedicalWebApplicationDomain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalWebApplicationDomain.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; } = Guid.NewGuid().ToString();
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }
}
