using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DichVuChuyenNha.Models;

public partial class DichVuChuyenNhaContext : DbContext
{
    public DichVuChuyenNhaContext()
    {
    }

    public DichVuChuyenNhaContext(DbContextOptions<DichVuChuyenNhaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DanhGia> DanhGia { get; set; }

    public virtual DbSet<DichVu> DichVus { get; set; }

    public virtual DbSet<DonHang> DonHangs { get; set; }

    public virtual DbSet<NguoiDung> NguoiDungs { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanCong> PhanCongs { get; set; }

    public virtual DbSet<PhuongTien> PhuongTiens { get; set; }

    public virtual DbSet<ThanhToan> ThanhToans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-9NCHNIC;Database=DichVuChuyenNhav2;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DanhGia>(entity =>
        {
            entity.HasKey(e => e.MaDanhGia).HasName("PK__DanhGia__75DAD655119281F2");

            entity.Property(e => e.MaDanhGia).HasColumnName("ma_danh_gia");
            entity.Property(e => e.BinhLuan)
                .HasColumnType("text")
                .HasColumnName("binh_luan");
            entity.Property(e => e.DiemDanhGia).HasColumnName("diem_danh_gia");
            entity.Property(e => e.MaDonHang).HasColumnName("ma_don_hang");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.DanhGia)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DanhGia_DonHang");
        });

        modelBuilder.Entity<DichVu>(entity =>
        {
            entity.HasKey(e => e.MaDichVu).HasName("PK__DichVu__5ADDD3451FB63AD8");

            entity.ToTable("DichVu");

            entity.Property(e => e.MaDichVu).HasColumnName("ma_dich_vu");
            entity.Property(e => e.ChiPhi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("chi_phi");
            entity.Property(e => e.MaDonHang).HasColumnName("ma_don_hang");
            entity.Property(e => e.TenDichVu)
                .HasMaxLength(100)
                .IsUnicode(true)
                .HasColumnName("ten_dich_vu");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.DichVus)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DichVu_DonHang");
        });

        modelBuilder.Entity<DonHang>(entity =>
        {
            entity.HasKey(e => e.MaDonHang).HasName("PK__DonHang__0246C5EA6A059F68");

            entity.ToTable("DonHang");

            entity.Property(e => e.MaDonHang).HasColumnName("ma_don_hang");
            entity.Property(e => e.ChiPhi)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("chi_phi");
            entity.Property(e => e.DiaChiDich)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("dia_chi_dich");
            entity.Property(e => e.DiaChiHienTai)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("dia_chi_hien_tai");
            entity.Property(e => e.MaKhachHang).HasColumnName("ma_khach_hang");
            entity.Property(e => e.MoTa)
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("mo_ta");
            entity.Property(e => e.NgayChuyen)
                .HasColumnType("datetime")
                .HasColumnName("ngay_chuyen");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("cho_xac_nhan")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.DonHangs)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DonHang_NguoiDung");
        });

        modelBuilder.Entity<NguoiDung>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PK__NguoiDun__19C32CF75B210C1B");

            entity.ToTable("NguoiDung");

            entity.HasIndex(e => e.Email, "UQ__NguoiDun__AB6E6164C3222BE3").IsUnique();

            entity.HasIndex(e => e.SoDienThoai, "UQ__NguoiDun__BD03D94C008C622A").IsUnique();

            entity.Property(e => e.MaNguoiDung).HasColumnName("ma_nguoi_dung");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.HoTen)
                .HasMaxLength(100)
                .IsUnicode(true)
                .HasColumnName("ho_ten");
            entity.Property(e => e.MatKhau)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("mat_khau");
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_tao");
            entity.Property(e => e.SoDienThoai)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("so_dien_thoai");
            entity.Property(e => e.VaiTro)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vai_tro");
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNhanVien).HasName("PK__NhanVien__6781B7B94C6B9390");

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNhanVien)
                .ValueGeneratedNever()
                .HasColumnName("ma_nhan_vien");
            entity.Property(e => e.TrangThaiSanSang)
                .HasDefaultValue(true)
                .HasColumnName("trang_thai_san_sang");
            entity.Property(e => e.ViTri)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vi_tri");

            entity.HasOne(d => d.MaNhanVienNavigation).WithOne(p => p.NhanVien)
                .HasForeignKey<NhanVien>(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_NhanVien_NguoiDung");
        });

        modelBuilder.Entity<PhanCong>(entity =>
        {
            entity.HasKey(e => e.MaPhanCong).HasName("PK__PhanCong__59F41CE32E4D4B5E");

            entity.ToTable("PhanCong");

            entity.Property(e => e.MaPhanCong).HasColumnName("ma_phan_cong");
            entity.Property(e => e.MaDonHang).HasColumnName("ma_don_hang");
            entity.Property(e => e.MaNhanVien).HasColumnName("ma_nhan_vien");
            entity.Property(e => e.NgayPhanCong)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("ngay_phan_cong");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.PhanCongs)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanCong_DonHang");

            entity.HasOne(d => d.MaNhanVienNavigation).WithMany(p => p.PhanCongs)
                .HasForeignKey(d => d.MaNhanVien)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanCong_NhanVien");
        });

        modelBuilder.Entity<PhuongTien>(entity =>
        {
            entity.HasKey(e => e.MaPhuongTien).HasName("PK__PhuongTi__2CDFA6B319B28647");

            entity.ToTable("PhuongTien");

            entity.HasIndex(e => e.BienSoXe, "UQ__PhuongTi__9466AB8ED128FD4E").IsUnique();

            entity.Property(e => e.MaPhuongTien).HasColumnName("ma_phuong_tien");
            entity.Property(e => e.BienSoXe)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("bien_so_xe");
            entity.Property(e => e.LoaiXe)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("loai_xe");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("san_sang")
                .HasColumnName("trang_thai");
        });

        modelBuilder.Entity<ThanhToan>(entity =>
        {
            entity.HasKey(e => e.MaThanhToan).HasName("PK__ThanhToa__F89DBB4F463E54BA");

            entity.ToTable("ThanhToan");

            entity.Property(e => e.MaThanhToan).HasColumnName("ma_thanh_toan");
            entity.Property(e => e.MaDonHang).HasColumnName("ma_don_hang");
            entity.Property(e => e.NgayThanhToan)
                .HasColumnType("datetime")
                .HasColumnName("ngay_thanh_toan");
            entity.Property(e => e.PhuongThuc)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phuong_thuc");
            entity.Property(e => e.SoTien)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("so_tien");
            entity.Property(e => e.TrangThai)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValue("cho_thanh_toan")
                .HasColumnName("trang_thai");

            entity.HasOne(d => d.MaDonHangNavigation).WithMany(p => p.ThanhToans)
                .HasForeignKey(d => d.MaDonHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ThanhToan_DonHang");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
