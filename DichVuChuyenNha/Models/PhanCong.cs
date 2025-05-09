using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DichVuChuyenNha.Models;

public partial class PhanCong
{
    [Display(Name = "Mã phân công")]
    public int MaPhanCong { get; set; }
    [Display(Name = "Mã đơn hàng")]
    public int MaDonHang { get; set; }
    [Display(Name = "Mã nhân viên")]
    public int MaNhanVien { get; set; }
    [Display(Name = "Ngày phân công")]
    public DateTime? NgayPhanCong { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; } = null!;

    public virtual NhanVien? MaNhanVienNavigation { get; set; } = null!;
}
