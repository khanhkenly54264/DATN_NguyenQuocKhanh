using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DichVuChuyenNha.Models;

public partial class ThanhToan
{
    [Display(Name = "Mã thanh toán")]
    public int MaThanhToan { get; set; }
    [Display(Name = "Mã đơn hàng")]
    public int MaDonHang { get; set; }
    [Display(Name = "Số tiền")]
    public decimal SoTien { get; set; }
    [Display(Name = "Phương thức")]
    public string PhuongThuc { get; set; } = null!;
    [Display(Name = "Trạng thái")]
    public string? TrangThai { get; set; }
    [Display(Name = "Ngày thanh toán")]
    public DateTime? NgayThanhToan { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; } = null!;
}
