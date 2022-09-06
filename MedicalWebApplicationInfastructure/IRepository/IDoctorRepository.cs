using MedicalWebApplicationDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWebApplicationInfastructure.IRepository
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
    }
}