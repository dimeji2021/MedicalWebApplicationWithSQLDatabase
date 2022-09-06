using MedicalWebApplicationDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWebApplicationInfastructure.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductsAsync();
    }
}