using MedicalWebApplicationDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWebApplicationInfastructure.IRepository
{
    public interface IUserRepository
    {
        Task<bool> AddUserToDataBaseAsync(User model);
        Task<User> GetUsersAsync(string email, string password);
        Task<User> CheckIfEmailAlreadyExistAsync(string email);
    }
}