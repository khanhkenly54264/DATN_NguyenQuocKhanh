using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DichVuChuyenNha.Models;

public partial class NhanVien
{
    [Display(Name = "Mã nhân viên")]
    public int MaNhanVien { get; set; }
    [Display(Name = "Vị trí")]
    public string? ViTri { get; set; }
    [Display(Name = "Trạng thái")]
    public bool? TrangThaiSanSang { get; set; }=true;

    public virtual NguoiDung? MaNhanVienNavigation { get; set; } = null!;

    public virtual ICollection<PhanCong> PhanCongs { get; set; } = new List<PhanCong>();
}
