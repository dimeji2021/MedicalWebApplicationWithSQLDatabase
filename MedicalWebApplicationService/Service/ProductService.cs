using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationInfastructure.IRepository;
using MedicalWebApplicationService.IService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebApplicationService.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productRepository.GetAllProductsAsync();
        }
    }
}
