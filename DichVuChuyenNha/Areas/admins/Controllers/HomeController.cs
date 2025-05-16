using DichVuChuyenNha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DichVuChuyenNha.Areas.admins.Controllers
{
    public class HomeController : BaseController
    {

        private readonly DichVuChuyenNhaContext _context;

        public HomeController(DichVuChuyenNhaContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ViewBag.TongKhachHang = _context.NguoiDungs.Count(n => n.VaiTro == "khach_hang");
            ViewBag.TongDonHangDXL = _context.DonHangs.Count(d => d.TrangThai == "hoan_thanh");
            ViewBag.TongDoanhThu = _context.ThanhToans
                .Where(d => d.TrangThai == "da_thanh_toan")
                .Sum(d => (decimal?)d.SoTien) ?? 0;
            ViewBag.TongDonHang = _context.DonHangs.Count(d => d.TrangThai != "hoan_thanh");
           
            return View();
        }
        // GET: admins/DonHangs/OrderChartData
        [HttpGet]
        public JsonResult OrderChartData()
        {
            // Lấy số lượng đơn hàng theo tháng (ví dụ: 12 tháng gần nhất)
            var data = _context.DonHangs
                .Where(d => d.NgayTao.HasValue) // Ensure NgayTao is not null
                .GroupBy(d => d.NgayTao.Value.Month) // Use Value to access Month
                .Select(g => new
                {
                    Month = g.Key,
                    Count = g.Count()
                })
                .OrderBy(g => g.Month)
                .ToList();

            // Tạo nhãn tháng (1-12)
            var labels = Enumerable.Range(1, 12).Select(m => $"{m}").ToArray();
            var orderCounts = new int[12];
            foreach (var d in data)
            {
                orderCounts[d.Month - 1] = d.Count;
            }

            return Json(new { labels, orderCounts });
        }
    }
}
