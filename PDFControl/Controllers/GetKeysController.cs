using Microsoft.AspNetCore.Mvc;
using PDFControl.Models;
using PDFControl.Models.ViewModels;
using PDFControl.Services;
namespace PDFControl.Controllers
{
    public class GetKeysController : Controller
    {
        private readonly ApiService _apiService;
        public GetKeysController(ApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
