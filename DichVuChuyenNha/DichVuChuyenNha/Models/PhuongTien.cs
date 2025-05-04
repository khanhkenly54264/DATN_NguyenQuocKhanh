using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DichVuChuyenNha.Models;

public partial class PhuongTien
{
    [Display(Name = "Mã phương tiện")]
    public int MaPhuongTien { get; set; }
    [Display(Name = "Biển số xe")]
    public string BienSoXe { get; set; } = null!;
    [Display(Name = "Lọai xe")]
    public string? LoaiXe { get; set; }
    [Display(Name = "Trạng thái")]
    public string? TrangThai { get; set; }
}
