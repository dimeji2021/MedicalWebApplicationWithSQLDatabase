using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalWebApplicationService.ViewModel
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Profile { get; set; }
        public string ImageUrl { get; set; }
        public string Comment { get; set; }
    }
}
