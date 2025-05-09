using DichVuChuyenNha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DichVuChuyenNha.Controllers
{
    public class DonHangController : Controller
    {
        private readonly DichVuChuyenNhaContext _context;

        public DonHangController(DichVuChuyenNhaContext context)
        {
            _context = context;
        }

        // GET: /DonHang/Create
        public IActionResult Create()
        {
            return View("~/Views/Home/Index.cshtml"); // Trả về view chính
        }

        // POST: /DonHang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DonHangViewModel viewModel)
        {
            Console.WriteLine("Create method called with viewModel: " +viewModel.DiaChiHienTai+viewModel.DiaChiDich+viewModel.ChiPhi+viewModel.NgayChuyen+viewModel.MoTa+viewModel.ServiceType+viewModel.dodac+viewModel.donggoi);
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
                ViewData["Message"] = "Dữ liệu không hợp lệ: " + string.Join(", ", errors);
                ViewData["Success"] = false;
                return View("~/Views/Home/Index.cshtml");
            }
            var userIdClaim = HttpContext.Session.GetInt32("Id_NguoiDung")??null;
            Console.WriteLine("User ID from session: " + userIdClaim);
            if (userIdClaim==null)
            {
                ViewData["Message"] = "Vui lòng đăng nhập để đặt lịch";
                ViewData["Success"] = false;

                return View("~/Views/Login/Index.cshtml");
            }
            try
            {
                Console.WriteLine("đã vao đây");
                var donHang = new DonHang
                {
                    MaKhachHang = userIdClaim??0,
                    DiaChiHienTai = viewModel.DiaChiHienTai,
                    DiaChiDich = viewModel.DiaChiDich,
                    ChiPhi = viewModel.ChiPhi,
                    NgayChuyen = viewModel.NgayChuyen,
                    MoTa =  viewModel.ServiceType != null ? $"{viewModel.MoTa}\nLoại dịch vụ: {viewModel.ServiceType switch { "basic" => "Gói cơ bản", "standard" => "Gói tiêu chuẩn", "premium" => "Gói cao cấp", _ => "Theo km" }}" : viewModel.MoTa+ "Dịch vụ " + viewModel.donggoi + viewModel.dodac,
                    TrangThai = "moi", // Trạng thái mặc định
                    NgayTao = DateTime.Now,
                };
                _context.Add(donHang);

                await _context.SaveChangesAsync();
/*                var tongDV = 0;
                if (viewModel.dodac != null)
                {
                    tongDV += 300000;
                }
                if (viewModel.donggoi != null)
                {
                    tongDV += 500000;
                }
                if (viewModel.donggoi != null || viewModel.dodac != null || viewModel.ServiceType != null)
                {
                    var dichVu = new DichVu
                    {
                        MaDonHang = ,
                        TenDichVu = viewModel.ServiceType ?? (viewModel.dodac + viewModel.donggoi),
                        ChiPhi = tongDV,
                    };

                    _context.Add(dichVu);
                }*/


                ViewData["Message"] = "Đặt lịch vận chuyển thành công!";
                ViewData["Success"] = true;
                return View("~/Views/Home/Index.cshtml");
            }
            catch (DbUpdateException ex)
            {
                ViewData["Message"] = "Lỗi cơ sở dữ liệu khi lưu đơn hàng. Vui lòng thử lại.";
                ViewData["Success"] = false;
                return View("~/Views/Home/Index.cshtml");
            }
            catch (Exception ex)
            {
                ViewData["Message"] = $"Lỗi không xác định: {ex.Message}";
                ViewData["Success"] = false;
                return View("~/Views/Home/Index.cshtml");
            }
        }
    }

    // View model for DonHang
    public class DonHangViewModel
    {
        [Required(ErrorMessage = "Vui lòng nhập địa chỉ xuất phát")]
        [StringLength(500, ErrorMessage = "Địa chỉ xuất phát không được vượt quá 500 ký tự")]
        public string DiaChiHienTai { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập địa chỉ đích")]
        [StringLength(500, ErrorMessage = "Địa chỉ đích không được vượt quá 500 ký tự")]
        public string DiaChiDich { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Chi phí phải lớn hơn hoặc bằng 0")]
        public decimal? ChiPhi { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn thời gian vận chuyển")]
        public DateTime NgayChuyen { get; set; }

        [StringLength(1000, ErrorMessage = "Ghi chú không được vượt quá 1000 ký tự")]
        public string? MoTa { get; set; }
        public string? dodac { get; set; }
        public string? donggoi { get; set; }
        public string? ServiceType { get; set; }
    }

    // DbContext for Entity Framework Core
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DonHang> DonHangs { get; set; }
        // Thêm các DbSet khác nếu cần
        // public DbSet<NguoiDung> NguoiDungs { get; set; }
        // public DbSet<DichVu> DichVus { get; set; }
        // public DbSet<DanhGia> DanhGias { get; set; }
        // public DbSet<PhanCong> PhanCongs { get; set; }
        // public DbSet<ThanhToan> ThanhToans { get; set; }
    }
}