using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DichVuChuyenNha.Models;

public partial class DichVu
{
    [Display(Name = "Mã dịch vụ")]
    public int MaDichVu { get; set; }
    [Display(Name = "Mã hóa đơn")]
    public int MaDonHang { get; set; }
    [Display(Name = "Tên dịch vụ")]
    public string TenDichVu { get; set; } = null!;
    [Display(Name = "Chi phí")]
    public decimal? ChiPhi { get; set; }

    public virtual DonHang? MaDonHangNavigation { get; set; } = null!;
}
