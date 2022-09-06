using MedicalWebApplication.Models;
using MedicalWebApplicationService.IService;
using MedicalWebApplicationService.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;
        private readonly IResearchStatisticsService _researchStatisticsService;
        private readonly IDoctorService _doctorServices;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IResearchStatisticsService researchStatisticsService, IDoctorService doctorServices)
        {
            _logger = logger;
            _productService = productService;
            _researchStatisticsService = researchStatisticsService;
            _doctorServices = doctorServices;
        }

        public async Task<IActionResult> Index(int page)
        {
            var products = await _productService.GetAllProducts();
            PaginationViewModel paginationViewModel = new PaginationViewModel();
            /*------------------------------------------------------------------------------*/
            paginationViewModel.PageSize = 4;
            paginationViewModel.CurrentPage = page == 0 ? 1 : page;

            double pages = (double)products.Count / paginationViewModel.PageSize;
            paginationViewModel.NumberPages = (int)Math.Round(pages, 0, MidpointRounding.AwayFromZero);
            var skip = 4 * (Convert.ToInt32(paginationViewModel.CurrentPage) - 1);
            paginationViewModel.Products = products.Skip(skip).Take(paginationViewModel.PageSize).ToList();

            if (paginationViewModel.CurrentPage == 1)
            {
                paginationViewModel.PreviousPage = 0;
            }
            else
            {
                paginationViewModel.PreviousPage = paginationViewModel.CurrentPage - 1;
            }
            if (paginationViewModel.CurrentPage != pages)
            {
                paginationViewModel.NextPage = paginationViewModel.CurrentPage + 1;
            }
            paginationViewModel.Research = await _researchStatisticsService.Calstat();
            paginationViewModel.Doctors = await _doctorServices.GetAllDoctorsAsync();
            /*---------------------------------------------------------------------------------*/

            return View(paginationViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
