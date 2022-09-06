using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationService.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWebApplicationService.IService
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<DoctorViewModel> GetDoctorById(int Id);
    }
}