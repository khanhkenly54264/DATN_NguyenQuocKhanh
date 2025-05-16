using Microsoft.AspNetCore.Mvc;

namespace DichVuChuyenNha.Controllers
{
    public class QuangCaoController : Controller
    {
        public IActionResult ChuyenNha()
        {
            return View();
        }
        public IActionResult ChuyenVanPhong()
        {
            return View();
        }
        public IActionResult ChuyenHang()
        {
            return View();
        }
    }
}
