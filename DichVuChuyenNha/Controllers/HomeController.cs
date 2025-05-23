using System.Diagnostics;
using DichVuChuyenNha.Models;
using Microsoft.AspNetCore.Mvc;

namespace DichVuChuyenNha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            return View();
        }
        public IActionResult Index1()
        {

            return View();
        }
        public IActionResult Baogia()
        {

            return View();
        }
        public IActionResult ChuyenHang()
        {

            return View();
        }
        public IActionResult LienHe()
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
