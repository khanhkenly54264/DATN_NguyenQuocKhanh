using CtyPhanPhoiDaSachHN.Models;
using DichVuChuyenNha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CtyPhanPhoiDaSachHN.Controllers
{
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
                if (user != null && user.VaiTro == "khach_hang")
                {
                    HttpContext.Session.SetInt32("Id_NguoiDung", user.MaNguoiDung);
                    HttpContext.Session.SetString("LoaiTaiKhoan", user.VaiTro);
                    HttpContext.Session.SetString("TenDangNhap", user.HoTen);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View("Index", model);


        }
        public IActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DangKy(NguoiDung model)
        {
            if(_context.NguoiDungs.Any(u => u.Email == model.Email))
    {
                ModelState.AddModelError("TenDangNhap", "Tên đăng nhập đã tồn tại.");
            }
            if (ModelState.IsValid)
            {
                var khachhang= new NguoiDung
                {
                    VaiTro = "khach_hang",
                    HoTen = model.HoTen,
                    Email = model.Email,
                    SoDienThoai = model.SoDienThoai,
                    MatKhau = model.MatKhau,
                    NgayTao = DateTime.Now,
                    TrangThai = true
                };
                _context.NguoiDungs.Add(khachhang);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        public IActionResult QuenMk()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> QuenMk(String TenDangNhap)
        {
            var tk = _context.NguoiDungs.Where(u => u.Email == TenDangNhap).FirstOrDefault();
            if (tk!=null)
            {
                ViewBag.Message = "Mật khẩu của bạn là: " + tk.MatKhau;
                return View();
            }
            else
            {
                ViewBag.Message = "Tên đăng nhập không tồn tại.";
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

    }
}
