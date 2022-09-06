using MedicalWebApplicationService.IService;
using MedicalWebApplicationService.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MedicalWebApplication.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authServcie;

        public AuthController(IAuthService authServcie)
        {
            _authServcie = authServcie;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var validate = await _authServcie.Register(model);
                if (validate)
                {
                    return RedirectToAction("Login", "Auth");
                }
                ModelState.AddModelError(string.Empty, "Email Already exist");

            }
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var user = await _authServcie.Login(model);
            if (user != null)
            {
                HttpContext.Session.SetString("FullName", user.FullName);
                HttpContext.Session.SetString("UserId", user.UserId);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "User does not exist");
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
