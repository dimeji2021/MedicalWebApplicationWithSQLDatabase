using MedicalWebApplicationDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWebApplicationService.IService
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProducts();
    }
}