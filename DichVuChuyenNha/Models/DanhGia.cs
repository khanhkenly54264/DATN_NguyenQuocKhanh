using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DichVuChuyenNha.Models;

public partial class DanhGia
{
    [Display(Name = "Mã đánh giá")]
    public int MaDanhGia { get; set; }
    [Display(Name = "Mã hóa đơn")]
    public int MaDonHang { get; set; }
    [Display(Name = "Điểm đánh giá")]
    public int? DiemDanhGia { get; set; }
    [Display(Name = "Bình luận")]
    public string? BinhLuan { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? NgayTao { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; } = null!;
}
