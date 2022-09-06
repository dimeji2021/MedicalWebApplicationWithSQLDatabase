using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationHelpers.IHelpers;
using MedicalWebApplicationInfastructure.IRepository;
using MedicalWebApplicationService.IService;
using MedicalWebApplicationService.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebApplicationService.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUtility _utility;
        private readonly IUserRepository _userRepository;
        public AuthService(IUtility utility, IUserRepository userRepository)
        {
            _utility = utility;
            _userRepository = userRepository;
        }

        public async Task<bool> Register(UserViewModel model)
        {
            var alreadyExist = await CheckIfEmailAlreadyExist(model.Email);
            if (alreadyExist)
            {
                return false;
            }
            else
            {
                var hashPassword = _utility.ComputeSha256Hash(model.Password);
                User user = new User()
                {
                    FullName = $"{model.FirstName} {model.LastName}",
                    Gender = model.Gender,
                    Email = model.Email,
                    Password = hashPassword,
                    PhoneNumber = model.PhoneNumber,
                };
                var isAdded = await _userRepository.AddUserToDataBaseAsync(user);
                return isAdded;
            }
        }
        public async Task<User> Login(LoginViewModel model)
        {
            var hashPassword = _utility.ComputeSha256Hash(model.Password);
            var users = await _userRepository.GetUsersAsync(model.Email,hashPassword);
            return users;
        }
        private async Task<bool> CheckIfEmailAlreadyExist(string email)
        {
            var users = await _userRepository.CheckIfEmailAlreadyExistAsync(email);
            //var user = users.Where(x => x.Email == email).FirstOrDefault();

            if (users != null)
            {
                return true;
            }
            return false;
        }
    }
}
