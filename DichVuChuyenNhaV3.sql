USE [master]
GO
/****** Object:  Database [DichVuChuyenNhaV3]    Script Date: 17/05/2025 3:10:36 SA ******/
CREATE DATABASE [DichVuChuyenNhaV3]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DichVuChuyenNhaV3', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DichVuChuyenNhaV3.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DichVuChuyenNhaV3_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\DichVuChuyenNhaV3_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DichVuChuyenNhaV3].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET ARITHABORT OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET  MULTI_USER 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'DichVuChuyenNhaV3', N'ON'
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET QUERY_STORE = ON
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [DichVuChuyenNhaV3]
GO
/****** Object:  Table [dbo].[DanhGia]    Script Date: 17/05/2025 3:10:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhGia](
	[ma_danh_gia] [int] IDENTITY(1,1) NOT NULL,
	[ma_don_hang] [int] NOT NULL,
	[diem_danh_gia] [int] NULL,
	[binh_luan] [text] NULL,
	[ngay_tao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_danh_gia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DichVu]    Script Date: 17/05/2025 3:10:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DichVu](
	[ma_dich_vu] [int] IDENTITY(1,1) NOT NULL,
	[ma_don_hang] [int] NOT NULL,
	[ten_dich_vu] [nvarchar](100) NULL,
	[chi_phi] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_dich_vu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 17/05/2025 3:10:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[ma_don_hang] [int] IDENTITY(1,1) NOT NULL,
	[ma_khach_hang] [int] NOT NULL,
	[dia_chi_hien_tai] [nvarchar](max) NULL,
	[dia_chi_dich] [nvarchar](max) NULL,
	[ngay_chuyen] [datetime] NOT NULL,
	[trang_thai] [varchar](20) NULL,
	[chi_phi] [decimal](10, 2) NULL,
	[mo_ta] [nvarchar](max) NULL,
	[ngay_tao] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_don_hang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NguoiDung]    Script Date: 17/05/2025 3:10:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NguoiDung](
	[ma_nguoi_dung] [int] IDENTITY(1,1) NOT NULL,
	[vai_tro] [varchar](20) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[so_dien_thoai] [varchar](15) NOT NULL,
	[mat_khau] [varchar](255) NOT NULL,
	[ngay_tao] [datetime] NULL,
	[ho_ten] [nvarchar](100) NULL,
	[TrangThai] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nguoi_dung] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[so_dien_thoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 17/05/2025 3:10:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ma_nhan_vien] [int] NOT NULL,
	[vi_tri] [varchar](20) NULL,
	[trang_thai_san_sang] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_nhan_vien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhanCong]    Script Date: 17/05/2025 3:10:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanCong](
	[ma_phan_cong] [int] IDENTITY(1,1) NOT NULL,
	[ma_don_hang] [int] NOT NULL,
	[ma_nhan_vien] [int] NOT NULL,
	[ngay_phan_cong] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_phan_cong] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PhuongTien]    Script Date: 17/05/2025 3:10:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhuongTien](
	[ma_phuong_tien] [int] IDENTITY(1,1) NOT NULL,
	[bien_so_xe] [varchar](20) NOT NULL,
	[loai_xe] [varchar](50) NULL,
	[trang_thai] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_phuong_tien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[bien_so_xe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThanhToan]    Script Date: 17/05/2025 3:10:37 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThanhToan](
	[ma_thanh_toan] [int] IDENTITY(1,1) NOT NULL,
	[ma_don_hang] [int] NOT NULL,
	[so_tien] [decimal](10, 2) NOT NULL,
	[phuong_thuc] [varchar](20) NOT NULL,
	[trang_thai] [varchar](20) NULL,
	[ngay_thanh_toan] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ma_thanh_toan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DanhGia] ADD  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT ('cho_xac_nhan') FOR [trang_thai]
GO
ALTER TABLE [dbo].[DonHang] ADD  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[NguoiDung] ADD  DEFAULT (getdate()) FOR [ngay_tao]
GO
ALTER TABLE [dbo].[PhanCong] ADD  DEFAULT (getdate()) FOR [ngay_phan_cong]
GO
ALTER TABLE [dbo].[PhuongTien] ADD  DEFAULT ('san_sang') FOR [trang_thai]
GO
ALTER TABLE [dbo].[ThanhToan] ADD  DEFAULT ('cho_thanh_toan') FOR [trang_thai]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [FK_DanhGia_DonHang] FOREIGN KEY([ma_don_hang])
REFERENCES [dbo].[DonHang] ([ma_don_hang])
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [FK_DanhGia_DonHang]
GO
ALTER TABLE [dbo].[DichVu]  WITH CHECK ADD  CONSTRAINT [FK_DichVu_DonHang] FOREIGN KEY([ma_don_hang])
REFERENCES [dbo].[DonHang] ([ma_don_hang])
GO
ALTER TABLE [dbo].[DichVu] CHECK CONSTRAINT [FK_DichVu_DonHang]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DonHang_NguoiDung] FOREIGN KEY([ma_khach_hang])
REFERENCES [dbo].[NguoiDung] ([ma_nguoi_dung])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DonHang_NguoiDung]
GO
ALTER TABLE [dbo].[NhanVien]  WITH CHECK ADD  CONSTRAINT [FK_NhanVien_NguoiDung] FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[NguoiDung] ([ma_nguoi_dung])
GO
ALTER TABLE [dbo].[NhanVien] CHECK CONSTRAINT [FK_NhanVien_NguoiDung]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_DonHang] FOREIGN KEY([ma_don_hang])
REFERENCES [dbo].[DonHang] ([ma_don_hang])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_DonHang]
GO
ALTER TABLE [dbo].[PhanCong]  WITH CHECK ADD  CONSTRAINT [FK_PhanCong_NhanVien] FOREIGN KEY([ma_nhan_vien])
REFERENCES [dbo].[NhanVien] ([ma_nhan_vien])
GO
ALTER TABLE [dbo].[PhanCong] CHECK CONSTRAINT [FK_PhanCong_NhanVien]
GO
ALTER TABLE [dbo].[ThanhToan]  WITH CHECK ADD  CONSTRAINT [FK_ThanhToan_DonHang] FOREIGN KEY([ma_don_hang])
REFERENCES [dbo].[DonHang] ([ma_don_hang])
GO
ALTER TABLE [dbo].[ThanhToan] CHECK CONSTRAINT [FK_ThanhToan_DonHang]
GO
ALTER TABLE [dbo].[DanhGia]  WITH CHECK ADD  CONSTRAINT [CHK_DiemDanhGia] CHECK  (([diem_danh_gia]>=(1) AND [diem_danh_gia]<=(5)))
GO
ALTER TABLE [dbo].[DanhGia] CHECK CONSTRAINT [CHK_DiemDanhGia]
GO
USE [master]
GO
ALTER DATABASE [DichVuChuyenNhaV3] SET  READ_WRITE 
GO
