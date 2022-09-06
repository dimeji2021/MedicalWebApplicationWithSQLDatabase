using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationService.ViewModel;
using System.Threading.Tasks;

namespace MedicalWebApplicationService.IService
{
    public interface IAuthService
    {
        Task<User> Login(LoginViewModel model);
        Task<bool> Register(UserViewModel model);
    }
}