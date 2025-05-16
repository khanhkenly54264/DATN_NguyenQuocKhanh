using Microsoft.AspNetCore.Mvc;

namespace DichVuChuyenNha.Areas.admins.Controllers
{
    public class ChamSocKhachHangController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
