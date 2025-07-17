using Microsoft.AspNetCore.Mvc;
using PDFControl.Models;
using PDFControl.Models.ViewModels;
using PDFControl.Services;
using System.Diagnostics;

namespace PDFControl.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService _apiService;

        public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;

        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var viewModel = new IndexViewModel
                {
                    dockeysModel = await _apiService.GetKeys(),
                    logprocessModel = new LogprocessModel()
                };
                return View("~/Views/Home/Index.cshtml", viewModel);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here for brevity)
                return View("Error");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
