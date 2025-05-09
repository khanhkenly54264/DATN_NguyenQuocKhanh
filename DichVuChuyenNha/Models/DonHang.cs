using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DichVuChuyenNha.Models;

public partial class DonHang
{
    [Display(Name = "Mã hóa đơn")]
    public int MaDonHang { get; set; }
    [Display(Name = "Mã khách hàng")]
    public int MaKhachHang { get; set; }
    [Display(Name = "Địa chỉ hiện tại")]
    public string DiaChiHienTai { get; set; } = null!;
    [Display(Name = "Địa chỉ điểm đến")]
    public string DiaChiDich { get; set; } = null!;
    [Display(Name = "Thời gian chuyển")]
    public DateTime NgayChuyen { get; set; }
    [Display(Name = "Trạng thái")]
    public string? TrangThai { get; set; }
    [Display(Name = "Tổng tiền")]
    public decimal? ChiPhi { get; set; }
    [Display(Name = "Ghi chú")]
    public string? MoTa { get; set; }
    [Display(Name = "Ngày tạo")]
    public DateTime? NgayTao { get; set; }

    public virtual ICollection<DanhGia> DanhGia { get; set; } = new List<DanhGia>();

    public virtual ICollection<DichVu> DichVus { get; set; } = new List<DichVu>();

    public virtual NguoiDung? MaKhachHangNavigation { get; set; } = null!;

    public virtual ICollection<PhanCong> PhanCongs { get; set; } = new List<PhanCong>();

    public virtual ICollection<ThanhToan> ThanhToans { get; set; } = new List<ThanhToan>();
}
