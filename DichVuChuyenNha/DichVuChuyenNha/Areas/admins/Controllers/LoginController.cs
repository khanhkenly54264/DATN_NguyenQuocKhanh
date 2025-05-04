using DichVuChuyenNha.Areas.admins.Models;
using DichVuChuyenNha.Models;
using Microsoft.AspNetCore.Mvc;

namespace CtyPhanPhoiDaSachHN.Areas.admins.Controllers
{
    [Area("admins")]
    public class LoginController : Controller
    {
        private readonly DichVuChuyenNhaContext _context;

        public LoginController(DichVuChuyenNhaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.NguoiDungs.FirstOrDefault(u => u.Email == model.TenDangNhap && u.MatKhau == model.MatKhau);
                if (user != null&&user.VaiTro=="admin")
                {
                    HttpContext.Session.SetString("UserId", user.MaNguoiDung.ToString());
                    HttpContext.Session.SetString("UserName", user.HoTen);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
                }
            }
            return View("Index", model);


        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
    
        public IActionResult dk() {
            return View();
        }
    }
}
