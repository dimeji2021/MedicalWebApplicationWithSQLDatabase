using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationHelpers.IHelpers;
using MedicalWebApplicationInfastructure.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebApplicationInfastructure.Repository
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly IConfiguration _configuration;

        public DoctorRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            var doctors = new List<Doctor>();
            string ConString = _configuration.GetConnectionString("DbConnection");
            using (SqlConnection connection = new SqlConnection(ConString))
            {
                   SqlCommand cm = new SqlCommand("spGetAllDoctors", connection);
                   connection.Open();
                   cm.CommandType = System.Data.CommandType.StoredProcedure;
                   SqlDataReader dr = await cm.ExecuteReaderAsync();
                while (dr.Read())
                {
                    Doctor doctor = new Doctor
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString(),
                        Profile= dr["Profile"].ToString(),
                        ImageUrl = dr["ImageUrl"].ToString(),
                        Comment = dr["Comment"].ToString()
                     };
                    doctors.Add(doctor);
                }
            }
            return doctors;
        }
   }
}
