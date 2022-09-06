using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationInfastructure.IRepository;
using MedicalWebApplicationService.IService;
using MedicalWebApplicationService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebApplicationService.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllDoctorsAsync();
        }
        public async Task<DoctorViewModel> GetDoctorById(int Id)
        {
            var docs = await _doctorRepository.GetAllDoctorsAsync();
            var doc = docs.Where(doc => doc.Id == Id).FirstOrDefault(); ;
         
            DoctorViewModel doctorViewModel = new DoctorViewModel()
            {
                Id = doc.Id,
                Name = doc.Name,
                Profile = doc.Profile,
                ImageUrl = doc.ImageUrl,
                Comment = doc.Comment,
            };
            return doctorViewModel;
        }
    }
}
