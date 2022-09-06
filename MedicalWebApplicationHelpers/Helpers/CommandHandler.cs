using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebApplicationHelpers.Helpers
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IConfiguration _configuration;

        public CommandHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<bool> AddToDataBase(string procedure, SqlParameter[] parameters)
        {
            string conString = _configuration.GetConnectionString("DbConnection");
            using (SqlConnection con = new SqlConnection(conString))
            {
                SqlCommand cm = new SqlCommand(procedure, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                foreach (var item in parameters)
                {
                    cm.Parameters.Add(item);
                }
              await cm.ExecuteNonQueryAsync();
            }
            return true;
        }
        public async Task<SqlDataReader> ReadAllFromDataBase<T>(string procedure)
        {

            string conString = _configuration.GetConnectionString("DbConnection");
            SqlConnection con = new SqlConnection(conString);
            
                SqlCommand cm = new SqlCommand(procedure, con)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                con.Open();
                var dr = await cm.ExecuteReaderAsync();
                return dr;  
        }
    }
}
