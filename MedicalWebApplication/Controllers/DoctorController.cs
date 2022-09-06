using MedicalWebApplicationService.IService;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalWebApplication.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorServices;
        public DoctorController(IDoctorService doctorServices)
        {
            _doctorServices = doctorServices;
        }
        public async Task<IActionResult> Doctor(int id)
        {

            return View(await _doctorServices.GetDoctorById(id));
        }
    }
}
