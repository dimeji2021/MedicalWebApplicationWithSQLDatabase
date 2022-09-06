using MedicalWebApplicationDomain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalWebApplicationService.ViewModel
{
    public class PaginationViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<Doctor> Doctors { get; set; }
        public ResearchStatisticsViewModel Research { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int NumberPages { get; set; }
        public int PreviousPage { get; set; }
        public int NextPage { get; set; }
    }
}
