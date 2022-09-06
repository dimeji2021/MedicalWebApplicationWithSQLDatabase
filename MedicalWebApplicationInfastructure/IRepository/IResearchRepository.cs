using MedicalWebApplicationDomain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MedicalWebApplicationInfastructure.IRepository
{
    public interface IResearchRepository
    {
        Task<List<ResearchStatistics>> GetAllStatisticsAsync();
    }
}