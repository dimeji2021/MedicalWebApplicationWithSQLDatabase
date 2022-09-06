using MedicalWebApplicationDomain.Models;
using MedicalWebApplicationInfastructure.IRepository;
using MedicalWebApplicationService.IService;
using MedicalWebApplicationService.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MedicalWebApplicationService.Service
{
    public class ResearchStatisticsService : IResearchStatisticsService
    {
        private readonly IResearchRepository _researchRepository;

        public ResearchStatisticsService(IResearchRepository researchRepository)
        {
            _researchRepository = researchRepository;
        }
        public async Task<ResearchStatisticsViewModel> Calstat()
        {

            ResearchStatisticsViewModel researchStatistics = new ResearchStatisticsViewModel();

            var stats = await GetAllStat();
            foreach (var stat in stats)
            {
                researchStatistics.NewResearch += stat.NewResearch;
                researchStatistics.CancerSupport += stat.CancerSupport;
                researchStatistics.CancerResearch += stat.CancerResearch;
            }
            researchStatistics.CancerSupport = CalcPercentage(researchStatistics.CancerSupport);
            return researchStatistics;
        }
        private async Task<List<ResearchStatistics>> GetAllStat()
        {
            return await _researchRepository.GetAllStatisticsAsync();
        }
        private double CalcPercentage(double data)
        {
            double result = data / 100;
            return result;
        }
    }
}
