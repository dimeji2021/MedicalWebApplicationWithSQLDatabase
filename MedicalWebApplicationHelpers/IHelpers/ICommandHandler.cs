using System.Data.SqlClient;
using System.Threading.Tasks;

namespace MedicalWebApplicationHelpers.Helpers
{
    public interface ICommandHandler
    {
        Task<bool> AddToDataBase(string procedure, SqlParameter[] parameters);
        Task<SqlDataReader> ReadAllFromDataBase<T>(string procedure);
    }
}