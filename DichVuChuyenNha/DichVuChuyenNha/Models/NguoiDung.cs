using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DichVuChuyenNha.Models;

public partial class NguoiDung
{
    [Display(Name = "Mã người dùng")]
    public int MaNguoiDung { get; set; }
    [Display(Name = "Vai trò")]
    public string VaiTro { get; set; } = null!;
    [Display(Name = "Họ tên người dùng")]
    public string HoTen { get; set; } = null!;
    [Display(Name = "Email")]
    public string Email { get; set; } = null!;
    [Display(Name = "Số điện thoại")]
    public string SoDienThoai { get; set; } = null!;
    [Display(Name = "Mật khẩu")]
    public string MatKhau { get; set; } = null!;
    [Display(Name = "Ngày tạo")]
    public DateTime? NgayTao { get; set; }
    public bool? TrangThai { get; set; } = true;
    public virtual ICollection<DonHang> DonHangs { get; set; } = new List<DonHang>();

    public virtual NhanVien? NhanVien { get; set; }
}
