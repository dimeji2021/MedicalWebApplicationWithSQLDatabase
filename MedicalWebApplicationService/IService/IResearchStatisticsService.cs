using MedicalWebApplicationService.ViewModel;
using System.Threading.Tasks;

namespace MedicalWebApplicationService.IService
{
    public interface IResearchStatisticsService
    {
        Task<ResearchStatisticsViewModel> Calstat();
    }
}