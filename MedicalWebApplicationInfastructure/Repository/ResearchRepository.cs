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
    public class ResearchRepository : IResearchRepository
    {
        private readonly IConfiguration _configuration;

        public ResearchRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
      
        public async Task<List<ResearchStatistics>> GetAllStatisticsAsync()
        {
            var researchs = new List<ResearchStatistics>();
            string ConString = _configuration.GetConnectionString("DbConnection");

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                SqlCommand cm = new SqlCommand("spGetAllResearch", connection);
                connection.Open();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader dr = await cm.ExecuteReaderAsync();
                while (dr.Read())
                {
                    ResearchStatistics research = new ResearchStatistics
                    {
                        NewResearch = Convert.ToInt32(dr["NewResearch"]),
                        CancerSupport = Convert.ToInt32(dr["CancerSupport"]),
                        CancerResearch = Convert.ToInt32(dr["CancerResearch"]),
                    };
                    researchs.Add(research);
                }
            }
            return researchs;
        }
    }
}
