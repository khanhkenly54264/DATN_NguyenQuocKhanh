using Microsoft.AspNetCore.Mvc;

namespace DichVuChuyenNha.Areas.admins.Controllers
{
    public class HomeController : BaseController
    {
        
        public IActionResult Index()
        {
            return View();
        }
    }
}
