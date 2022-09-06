using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationHelpers.IHelpers;
using MedicalWebApplicationInfastructure.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebApplicationInfastructure.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Product>> GetAllProductsAsync()
        {

            var products = new List<Product>();
            string ConString = _configuration.GetConnectionString("DbConnection");

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                SqlCommand cm = new SqlCommand("spGetAllProducts", connection);
                connection.Open();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = await cm.ExecuteReaderAsync();
                while (dr.Read())
                {
                    Product product = new Product
                    {
                        ProductImageUrl = dr["ProductImageUrl"].ToString(),
                        ProductDescription = dr["ProductDescription"].ToString(),
                        ProductName = dr["ProductName"].ToString(),
                        ProductLink = dr["ProductLink"].ToString(),
                    };
                    products.Add(product);
                }
            }
            return products;
        }
    }
}
