using MedicalWebApplicationDomain.Enums;
using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationHelpers.IHelpers;
using MedicalWebApplicationInfastructure.IRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebApplicationInfastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _configuration;

        public UserRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<User> GetUsersAsync(string email, string password)
        {
            string ConString = _configuration.GetConnectionString("DbConnection");

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                SqlCommand cm = new SqlCommand("spGetUser", connection);
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@Email", email);
                cm.Parameters.AddWithValue("@Password", password);
                connection.Open();
                SqlDataReader dr = await cm.ExecuteReaderAsync();
                while (dr.Read())
                {
                    User user = new User
                    {
                        UserId = dr["UserId"].ToString(),
                        FullName = dr["FullName"].ToString(),
                        Email = dr["Email"].ToString(),
                        Gender = (Gender)dr["Gender"],
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        Password = dr["Password"].ToString(),
                        IsActive = Convert.ToBoolean(dr["IsActive"]),
                        DateCreated = Convert.ToDateTime(dr["DateCreated"]),
                    };
                    return user;
                }
                return null;
            }
        }
        public async Task<User> CheckIfEmailAlreadyExistAsync(string email)
        {
            string ConString = _configuration.GetConnectionString("DbConnection");

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                SqlCommand cm = new SqlCommand("spVerifyEmail", connection);
                connection.Open();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@Email", email);
                SqlDataReader dr = await cm.ExecuteReaderAsync();
                while (dr.Read())
                {
                    User user = new User
                    {
                        UserId = dr["UserId"].ToString(),
                        FullName = dr["FullName"].ToString(),
                        Email = dr["Email"].ToString(),
                        Gender = (Gender)dr["Gender"],
                        PhoneNumber = dr["PhoneNumber"].ToString(),
                        Password = dr["Password"].ToString(),
                        IsActive = Convert.ToBoolean(dr["IsActive"]),
                        DateCreated = Convert.ToDateTime(dr["DateCreated"]),
                    };
                    return user;
                }
                return null;
            }
        }
        public async Task<bool> AddUserToDataBaseAsync(User model)
        {
            string ConString = _configuration.GetConnectionString("DbConnection");

            using (SqlConnection connection = new SqlConnection(ConString))
            {
                SqlCommand cm = new SqlCommand("spAddUser", connection);
                connection.Open();
                cm.CommandType = System.Data.CommandType.StoredProcedure;
                cm.Parameters.AddWithValue("@UserId", model.UserId);
                cm.Parameters.AddWithValue("@FullName", model.FullName);
                cm.Parameters.AddWithValue("@Email", model.Email);
                cm.Parameters.AddWithValue("@Gender", model.Gender);
                cm.Parameters.AddWithValue("@PhoneNumber", model.PhoneNumber);
                cm.Parameters.AddWithValue("@Password", model.Password);
                cm.Parameters.AddWithValue("@IsActive", model.IsActive);
                cm.Parameters.AddWithValue("@DateCreated", model.DateCreated);
                await cm.ExecuteNonQueryAsync();
                return true;
            }
        }
    }
}
