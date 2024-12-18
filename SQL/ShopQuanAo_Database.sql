USE [ShopQuanAo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](max) NOT NULL,
	[Gender] [nvarchar](max) NULL,
	[Date] [datetime2](7) NULL,
	[Address] [nvarchar](max) NULL,
	[Image] [nvarchar](max) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ChiTietHoaDon]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHoaDon](
	[MaHD] [int] NOT NULL,
	[IDCTSP] [int] NOT NULL,
	[SoLuongMua] [int] NOT NULL,
	[GiaMua] [money] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC,
	[IDCTSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDM] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](100) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[NguoiTao] [nvarchar](100) NOT NULL,
	[NgaySua] [datetime] NOT NULL,
	[NguoiSua] [nvarchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHD] [int] IDENTITY(1,1) NOT NULL,
	[MaTK] [nvarchar](450) NOT NULL,
	[NgayDat] [datetime] NOT NULL,
	[GhiChu] [ntext] NULL,
	[TrangThai] [int] NOT NULL,
	[HoTenNguoiNhan] [nvarchar](100) NOT NULL,
	[DiaChiNhan] [nvarchar](100) NOT NULL,
	[SoDienThoaiNhan] [char](11) NOT NULL,
	[NgaySua] [datetime] NULL,
	[NguoiSua] [nvarchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KichCo]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KichCo](
	[MaKichCo] [int] IDENTITY(1,1) NOT NULL,
	[TenKichCo] [nvarchar](10) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaKichCo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [int] IDENTITY(1,1) NOT NULL,
	[MaDM] [int] NOT NULL,
	[TenSP] [nvarchar](150) NOT NULL,
	[Gia] [money] NOT NULL,
	[MoTa] [ntext] NOT NULL,
	[ChatLieu] [nvarchar](50) NOT NULL,
	[HuongDan] [ntext] NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[NguoiTao] [nvarchar](100) NOT NULL,
	[NgaySua] [datetime] NOT NULL,
	[NguoiSua] [nvarchar](100) NOT NULL,
	[MaMau] [char](10) NOT NULL,
	[HinhAnh] [nvarchar](150) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPhamChiTiet]    Script Date: 11/19/2024 8:56:45 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPhamChiTiet](
	[IDCTSP] [int] IDENTITY(1,1) NOT NULL,
	[MaSP] [int] NOT NULL,
	[MaKichCo] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[IDCTSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241025084903_InitialCreate', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241028053330_AddImageCustomer', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241028073046_AddUniqueConstraints', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241028151026_AddIsActiveCustomer', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241030150336_InitUser', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241031135305_UserAddressCanNull', N'8.0.10')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'a31e3d29-8dca-4690-bbce-435003be8bb4', N'Customer', N'CUSTOMER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'b28c55e3-c3d9-4158-94b2-2d58427db609', N'SuperAdmin', N'SUPERADMIN', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'f4669458-a50f-4e1c-b9dd-2f3bbdc886c0', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'1ea09427-6856-40fd-b2f3-b0e9695812b3', N'a31e3d29-8dca-4690-bbce-435003be8bb4')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'8f086f96-f347-48a4-ac2c-33d86b18764d', N'b28c55e3-c3d9-4158-94b2-2d58427db609')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'58c93490-4be0-4c94-bfde-1ae9205bbc1a', N'f4669458-a50f-4e1c-b9dd-2f3bbdc886c0')
GO
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Gender], [Date], [Address], [Image], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1ea09427-6856-40fd-b2f3-b0e9695812b3', N'Trần Thị Hạ Long', N'Nam', CAST(N'2024-11-14T00:00:00.0000000' AS DateTime2), N'abc', N'/Images/CustomerAvatars/0545a01b-24b7-4d46-a846-7f720c92dcdf_powerpuff_girl1.png', N'halong122002@gmail.com', N'HALONG122002@GMAIL.COM', N'halong122002@gmail.com', N'HALONG122002@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEMcKRpa/4ZQirWkwPgrwMbZ/Xo3GMikyiGuIqZz2SIBdBGxiLk/tOLD0LSAFDxxENg==', N'QFKS26A5P2D4R24WS7TM4XXGOKJT2TFJ', N'fc1c5955-8641-4c49-826e-b2db5a9cd785', N'0123456789', 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Gender], [Date], [Address], [Image], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'58c93490-4be0-4c94-bfde-1ae9205bbc1a', N'Admin', NULL, NULL, NULL, NULL, N'admin@gmail.com', N'ADMIN@GMAIL.COM', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAENYgYQSb1VXmm6Nd0yGGLuLXG+RfQKhfpue3Bpf5vDMksA8ZJ8/2I6TROK5OGusNCQ==', N'2GHIKJLZX3P64ZCZAIJJGILK76BGHYLD', N'9b118725-9f38-4819-88de-576ae1e11caa', NULL, 0, 0, CAST(N'2024-11-18T17:18:18.3365115+00:00' AS DateTimeOffset), 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [FullName], [Gender], [Date], [Address], [Image], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'8f086f96-f347-48a4-ac2c-33d86b18764d', N'Super Admin', NULL, NULL, NULL, NULL, N'superadmin@gmail.com', N'SUPERADMIN@GMAIL.COM', N'superadmin@gmail.com', N'SUPERADMIN@GMAIL.COM', 1, N'AQAAAAIAAYagAAAAEP8Oyo//luJu/eaLWyOzh6t3YTjACbatWq2QPT6uBdLuLTAYJ/Bobi8LKI5SP3miMA==', N'AZQKS5E4Q6Y76G5O4Y4AEYKWQPOB4RNZ', N'dce2cf46-43c5-4479-bc32-68f779609183', NULL, 0, 0, CAST(N'2024-11-18T16:31:19.2270387+00:00' AS DateTimeOffset), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[DanhMuc] ON 

INSERT [dbo].[DanhMuc] ([MaDM], [TenDanhMuc], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua]) VALUES (1, N'Áo phông', CAST(N'2021-08-07T20:45:45.887' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:45:45.887' AS DateTime), N'Nguyễn Viết Lộc')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDanhMuc], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua]) VALUES (2, N'Áo sơ mi', CAST(N'2021-08-07T20:45:55.990' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:45:55.990' AS DateTime), N'Nguyễn Viết Lộc')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDanhMuc], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua]) VALUES (3, N'Quần jeans', CAST(N'2021-08-07T20:46:04.060' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:46:04.060' AS DateTime), N'Nguyễn Viết Lộc')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDanhMuc], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua]) VALUES (4, N'Quần khaki', CAST(N'2021-08-07T20:46:11.890' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:46:11.890' AS DateTime), N'Nguyễn Viết Lộc')
INSERT [dbo].[DanhMuc] ([MaDM], [TenDanhMuc], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua]) VALUES (5, N'Quần short', CAST(N'2021-08-07T20:46:20.307' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:46:20.307' AS DateTime), N'Nguyễn Viết Lộc')
SET IDENTITY_INSERT [dbo].[DanhMuc] OFF
GO
SET IDENTITY_INSERT [dbo].[KichCo] ON 

INSERT [dbo].[KichCo] ([MaKichCo], [TenKichCo]) VALUES (1, N'S')
INSERT [dbo].[KichCo] ([MaKichCo], [TenKichCo]) VALUES (2, N'M')
INSERT [dbo].[KichCo] ([MaKichCo], [TenKichCo]) VALUES (3, N'L')
INSERT [dbo].[KichCo] ([MaKichCo], [TenKichCo]) VALUES (4, N'XL')
INSERT [dbo].[KichCo] ([MaKichCo], [TenKichCo]) VALUES (5, N'XXL')
INSERT [dbo].[KichCo] ([MaKichCo], [TenKichCo]) VALUES (6, N'XXXL')
SET IDENTITY_INSERT [dbo].[KichCo] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (1, 1, N'Áo phông nữ in họa tiết', 199000.0000, N'Đây là áo phông in hình họa tiết dành cho nữ', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T20:47:28.690' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2024-11-19T13:34:28.117' AS DateTime), N'Super Admin', N'#f2eeee   ', N'/UserImage/images/1263093311ap1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (2, 4, N'Quần khaki nam slimfit', 599000.0000, N'Chiếc quần khaki dành cho nam cá tính và sành điệu', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T20:48:18.767' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:48:18.767' AS DateTime), N'Nguyễn Viết Lộc', N'#e3c0c0   ', N'/UserImage/images/1295056379kk1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (3, 3, N'Quần jean nữ ôm body', 499000.0000, N'Đây là chiếc quần jean phù hợp cho các bạn năng động và cá tính', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T20:49:23.977' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:49:23.977' AS DateTime), N'Nguyễn Viết Lộc', N'#a088d7   ', N'/UserImage/images/646003228qj1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (4, 5, N'Quần short nam cá tính', 299000.0000, N'Quần short 1 màu phù hợp cho các hoạt động dã ngoại và thể thao', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T20:50:29.357' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:50:29.357' AS DateTime), N'Nguyễn Viết Lộc', N'#8d7f25   ', N'/UserImage/images/460718643s1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (5, 2, N'Áo sơ mi nam cộc kẻ tay caro', 399000.0000, N'Chiếc áo sơ mi cá tính dành cho các bạn nam thể hiện độ khỏe khoắn nam tính', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T20:52:08.440' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:52:08.440' AS DateTime), N'Nguyễn Viết Lộc', N'#000000   ', N'/UserImage/images/149933158sm1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (6, 1, N'Áo phông nam trơn', 199000.0000, N'Áo phông nam trơn phù hợp cho các hoạt động thể thao tại nhà', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T20:53:02.030' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T20:53:02.030' AS DateTime), N'Nguyễn Viết Lộc', N'#ddd9d9   ', N'/UserImage/images/2001683938ap2.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (7, 4, N'Quần khaki nam slimfit', 399000.0000, N'Đây là chiếc quần khaki cho nam style USA', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:12:08.827' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:12:08.827' AS DateTime), N'Nguyễn Viết Lộc', N'#d0c8c8   ', N'/UserImage/images/1535757629kk1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (8, 1, N'Áo phông kẻ ngang', 199000.0000, N'Áo phông nam phù hợp cho các hoạt động ở nhà', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:13:24.727' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:13:24.727' AS DateTime), N'Nguyễn Viết Lộc', N'#7abccd   ', N'/UserImage/images/1999396858qdq.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (9, 1, N'Áo ba lỗ', 129000.0000, N'Chiếc áo ba lỗ thoáng mát', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:14:18.867' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:14:18.867' AS DateTime), N'Nguyễn Viết Lộc', N'#b2aa38   ', N'/UserImage/images/12857977ap11.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (10, 3, N'Quần jeans nam slimfit', 499000.0000, N'Quần jeans nam trẻ trung cá tính cho giới trẻ', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng hoá chất tẩy Có chứa clo.
Phơi trong bóng mát.
Sấy khô, nhẹ nhàng.
Là ở nhiệt độ thấp 110 độ c.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:15:20.803' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:15:20.803' AS DateTime), N'Nguyễn Viết Lộc', N'#31315e   ', N'/UserImage/images/1412737438qj4.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (11, 3, N'Quần jeans nữ ống loe', 399000.0000, N'Quần jeans thời thượng cho nữ', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:16:27.047' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:16:27.047' AS DateTime), N'Nguyễn Viết Lộc', N'#1e2a3e   ', N'/UserImage/images/719239871qj2.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (12, 5, N'Quần short nữ', 199000.0000, N'Quần short nữ phù hợp cho những bạn nữ cá tính', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:17:23.327' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:17:23.327' AS DateTime), N'Nguyễn Viết Lộc', N'#050505   ', N'/UserImage/images/1023180088s13.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (13, 1, N'Áo phông nam họa tiết', 199000.0000, N'Áo phông nam cá tính', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:18:24.893' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:18:24.893' AS DateTime), N'Nguyễn Viết Lộc', N'#2982c7   ', N'/UserImage/images/50782552ap3.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (14, 2, N'Áo sơ mi nam xen kẽ', 299000.0000, N'Áo sơ mi thanh lịch dành cho những cuộc hẹn lãng mạn', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:19:26.057' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:19:26.057' AS DateTime), N'Nguyễn Viết Lộc', N'#db9fc2   ', N'/UserImage/images/1771603241sm13.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (15, 1, N'Áo phông nam trơn', 199000.0000, N'Áo phông nam trơn màu tím mộng mơ', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:20:15.877' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:20:15.877' AS DateTime), N'Nguyễn Viết Lộc', N'#211d58   ', N'/UserImage/images/852857560ap4.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (16, 3, N'Quần jeans nữ cá tính', 399000.0000, N'Quần jeans nữ phù hợp cho những bạn nữ cá tính và cute', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:21:17.887' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:21:17.887' AS DateTime), N'Nguyễn Viết Lộc', N'#6e82bf   ', N'/UserImage/images/1294937339qj6.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (17, 1, N'Áo phông nam Marvel', 299000.0000, N'Áo phông nam in họa tiết Marvel cho fan', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:23:22.160' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:23:22.163' AS DateTime), N'Nguyễn Viết Lộc', N'#000000   ', N'/UserImage/images/659481953mv.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (18, 3, N'Quần jeans nữ ống rộng', 399000.0000, N'Quần jeans nữ cá tính dễ phối đồ', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:24:13.657' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:24:13.657' AS DateTime), N'Nguyễn Viết Lộc', N'#121212   ', N'/UserImage/images/452637918qj3.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (19, 5, N'Quần short nam trơn', 199000.0000, N'Quần short nam dễ phối đồ', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:25:03.777' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:25:03.777' AS DateTime), N'Nguyễn Viết Lộc', N'#be6c2d   ', N'/UserImage/images/1674284951s1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (20, 2, N'Áo sơ mi kẻ dọc', 399000.0000, N'Áo sơ mi nam thanh lịch phù hợp cho dân cổ nhuế', N'90% cotton 10% spefix', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:26:07.140' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:26:07.140' AS DateTime), N'Nguyễn Viết Lộc', N'#1d1b1b   ', N'/UserImage/images/268717625sm10.jpeg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (21, 2, N'Áo sơ mi kẻ caro', 299000.0000, N'Áo sơ mi thanh lịch phù hợp cho những cuộc vui ', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:27:02.343' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:27:02.343' AS DateTime), N'Nguyễn Viết Lộc', N'#dc5685   ', N'/UserImage/images/1223530049sm4.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (22, 2, N'Áo sơ mi nữ cộc tay', 199000.0000, N'Áo sơ mi nữ cá tính dành cho các bạn nữ cute', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:28:28.597' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:28:28.597' AS DateTime), N'Nguyễn Viết Lộc', N'#b9a6b3   ', N'/UserImage/images/1617268626sm5.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (23, 5, N'Quần short nam kẻ sọc', 199000.0000, N'Quần short nam thể thao thoáng mát', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:29:19.330' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:29:19.330' AS DateTime), N'Nguyễn Viết Lộc', N'#928181   ', N'/UserImage/images/3038209s14.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (24, 2, N'Áo sơ mi nam họa tiết chấm bi', 299000.0000, N'Áo sơ mi thanh lịch phù hợp cho những cuộc hẹn quan trọng', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:30:09.143' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:30:09.143' AS DateTime), N'Nguyễn Viết Lộc', N'#181132   ', N'/UserImage/images/109876356sm3.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (25, 5, N'Quần short nam trơn', 199000.0000, N'Quần short nam dáng thể thao cho các hoạt động vui chơi', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.
', CAST(N'2021-08-07T21:30:55.683' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:30:55.683' AS DateTime), N'Nguyễn Viết Lộc', N'#000000   ', N'/UserImage/images/820907250s5.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (26, 5, N'Quần short nam bò', 299000.0000, N'Quần short bò cá tính dành cho các bạn nam', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:31:45.437' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:31:45.437' AS DateTime), N'Nguyễn Viết Lộc', N'#2e2424   ', N'/UserImage/images/89433323s7.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (27, 5, N'Quần short bò nữ', 299000.0000, N'Quần short bò nữ cá tính cute', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:33:03.477' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:33:03.477' AS DateTime), N'Nguyễn Viết Lộc', N'#4c3d71   ', N'/UserImage/images/1653867685s12.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (28, 5, N'Quần short bò nữ', 299000.0000, N'Quần short bò nữ cá tính cute', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:33:05.790' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:33:05.790' AS DateTime), N'Nguyễn Viết Lộc', N'#4c3d71   ', N'/UserImage/images/1326003637s12.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (29, 1, N'Áo phông nữ cá tính', 199000.0000, N'Áo phông nữ cá tính và dễ thương', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:34:05.683' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:34:05.683' AS DateTime), N'Nguyễn Viết Lộc', N'#91df8b   ', N'/UserImage/images/1789188102ap5.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (30, 1, N'Áo phông nữ in họa tiết', 199000.0000, N'Áo phông nữ cá tính và dễ thương', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:34:57.953' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:34:57.953' AS DateTime), N'Nguyễn Viết Lộc', N'#d9c4c4   ', N'/UserImage/images/587190902qj1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (31, 3, N'Quần jeans nam cá tính', 299000.0000, N'Quần jeans nam rách trang trí khỏe mạnh', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:36:14.077' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:36:14.077' AS DateTime), N'Nguyễn Viết Lộc', N'#000000   ', N'/UserImage/images/1933754734qj5.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (32, 3, N'Quần jeans nam dánh joger', 299000.0000, N'Quần jeans nam dáng joger thoáng mát', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:37:03.483' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:37:03.483' AS DateTime), N'Nguyễn Viết Lộc', N'#131d34   ', N'/UserImage/images/1815799531qj7.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (33, 4, N'Quần khaki nam  cotton slimfit', 399000.0000, N'Quần khaki thanh lịch dành cho nam', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:38:07.293' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:38:07.293' AS DateTime), N'Nguyễn Viết Lộc', N'#839348   ', N'/UserImage/images/noimage.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (34, 3, N'Quần jeans nữ cá tính', 399000.0000, N'Quần jeans nữ cá tính dễ phối đồ', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:39:01.377' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:39:01.377' AS DateTime), N'Nguyễn Viết Lộc', N'#100f0f   ', N'/UserImage/images/189542530qj11.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (35, 1, N'Áo phông Unisex', 199000.0000, N'Áo phông nam unisex dễ phối đồ', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:40:03.103' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:40:03.103' AS DateTime), N'Nguyễn Viết Lộc', N'#000000   ', N'/UserImage/images/1057869279ap6.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (36, 1, N'Áo phông nữ cá tính', 199000.0000, N'Áo phông nữ dễ phối đồ', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:40:50.277' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:40:50.277' AS DateTime), N'Nguyễn Viết Lộc', N'#d8d46f   ', N'/UserImage/images/729134479ap15.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (37, 4, N'Quần khaki nam slimfit', 399000.0000, N'Áo khaki dễ phối đồ và hiện đại', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:41:48.547' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:41:48.547' AS DateTime), N'Nguyễn Viết Lộc', N'#191529   ', N'/UserImage/images/967357481kk3.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (38, 4, N'Quần khaki nam slimfit', 399000.0000, N'Quần khaki nam dễ phối đồ', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:42:45.657' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:42:45.657' AS DateTime), N'Nguyễn Viết Lộc', N'#be4646   ', N'/UserImage/images/343928679kk7.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (39, 1, N'Áo phông nam in họa tiết', 199000.0000, N'Áo phông nam cotton dễ phối đồ', N'100% cotton', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:43:39.173' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:43:39.173' AS DateTime), N'Nguyễn Viết Lộc', N'#be9bc5   ', N'/UserImage/images/1963795176ap12.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (40, 4, N'Quần khaki dáng jogger', 390000.0000, N'Quần khaki thoáng mát', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:45:46.593' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:45:46.593' AS DateTime), N'Nguyễn Viết Lộc', N'#a8a0bb   ', N'/UserImage/images/noimage.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (41, 3, N'Quần jeans nữ cá tính', 399000.0000, N'Quần jeans cá tính dành cho các bạn nữ năng động', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:46:40.637' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:46:40.637' AS DateTime), N'Nguyễn Viết Lộc', N'#594b8b   ', N'/UserImage/images/1611007208qj8.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (42, 3, N'Quần khaki nam  cotton slimfit', 499000.0000, N'Quần jeans nam tôn dáng', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:47:31.080' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:47:31.080' AS DateTime), N'Nguyễn Viết Lộc', N'#1c205a   ', N'/UserImage/images/1799979480qj13.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (43, 5, N'Quần short nam trơn', 199000.0000, N'Quần short trơn một màu thoải mái', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:48:19.340' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:48:19.340' AS DateTime), N'Nguyễn Viết Lộc', N'#d7c1e6   ', N'/UserImage/images/1494584410s3.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (44, 5, N'Quần short nam họa tiết', 199000.0000, N'Quần short nam phù hợp cho đi biển', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:49:42.093' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:49:42.093' AS DateTime), N'Nguyễn Viết Lộc', N'#6e5959   ', N'/UserImage/images/839063203s11.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (45, 2, N'Áo sơ mi kẻ caro', 299000.0000, N'Áo sơ mi thanh lịch cho các bạn nam', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:50:27.563' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:50:27.563' AS DateTime), N'Nguyễn Viết Lộc', N'#382e2e   ', N'/UserImage/images/404854548sm1.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (46, 5, N'Quần short in họa tiết chấm bi', 199000.0000, N'Quần short nam chấm bi dễ thương và năng động', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:51:25.063' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:51:25.063' AS DateTime), N'Nguyễn Viết Lộc', N'#5d4646   ', N'/UserImage/images/6219096s9.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (47, 2, N'Áo sơ mi nam kẻ caro', 399000.0000, N'Áo sơ mi nam khỏe khoắn và nam tính', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:52:23.293' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:52:23.293' AS DateTime), N'Nguyễn Viết Lộc', N'#6e58bb   ', N'/UserImage/images/1972769708sm7.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (48, 5, N'Quần short ngủ nam', 199000.0000, N'Quần ngủ short nam', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:53:10.810' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:53:10.810' AS DateTime), N'Nguyễn Viết Lộc', N'#8c8282   ', N'/UserImage/images/1030516184s10.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (49, 5, N'Quần short nam trơn', 199000.0000, N'Quần short nam màu tím mộng mơ', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:53:58.300' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:53:58.300' AS DateTime), N'Nguyễn Viết Lộc', N'#141325   ', N'/UserImage/images/694690451s6.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (50, 1, N'Áo phông nam in chữ', 199000.0000, N'Áo phông nam màu cam in chữ dễ phối đồ', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:54:54.260' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:54:54.260' AS DateTime), N'Nguyễn Viết Lộc', N'#8e4c1a   ', N'/UserImage/images/2031305429ap14.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (51, 3, N'Quần jeans nam slimfit', 399000.0000, N'Quần jeans nam năng động tôn dáng', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:56:10.167' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:56:10.167' AS DateTime), N'Nguyễn Viết Lộc', N'#0e1243   ', N'/UserImage/images/347461011qj12.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (52, 2, N'Sơ mi nam trơn', 399000.0000, N'Áo sơ mi trơn tôn dáng', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:56:52.323' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:56:52.323' AS DateTime), N'Nguyễn Viết Lộc', N'#e2cbcb   ', N'/UserImage/images/98289066sm6.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (53, 2, N'Áo sơ mi nam kẻ caro', 399000.0000, N'Áo sơ mi nam cá tính', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:57:32.750' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:57:32.750' AS DateTime), N'Nguyễn Viết Lộc', N'#6c72cb   ', N'/UserImage/images/1120598985sm2.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (54, 1, N'Áo phông nam in họa tiết', 199000.0000, N'Áo phông nam chuẩn men dễ phối đồ', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:58:14.350' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:58:14.350' AS DateTime), N'Nguyễn Viết Lộc', N'#e8e473   ', N'/UserImage/images/1627604989ap7.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (55, 4, N'Quần khaki nam slimfit', 399000.0000, N'Quần khaki slimfit thanh lịch và trang nhã', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:59:05.070' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:59:05.070' AS DateTime), N'Nguyễn Viết Lộc', N'#95a739   ', N'/UserImage/images/13374572kk6.jpeg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (56, 3, N'Quần jeans nữ ống loe', 399000.0000, N'Quần jeans nữ cá tính dễ phối đồ', N'90% cotton 10% bò', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T21:59:46.750' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T21:59:46.750' AS DateTime), N'Nguyễn Viết Lộc', N'#8457a2   ', N'/UserImage/images/1103636750qj9.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (57, 1, N'Áo phông nam in hình', 199000.0000, N'Áo phông nam in hình dễ phối đồ thoáng mát', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T22:00:29.180' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T22:00:29.180' AS DateTime), N'Nguyễn Viết Lộc', N'#1c1c1c   ', N'/UserImage/images/1453801663ap10.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (58, 2, N'Sơ mi nam trơn', 399000.0000, N'Áo sơ mi nam trơn trang nhã và thanh lịch', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T22:01:14.633' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T22:01:14.633' AS DateTime), N'Nguyễn Viết Lộc', N'#7d72ca   ', N'/UserImage/images/1370964899sm8.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (59, 2, N'Áo sơ mi nam cộc tay', 399000.0000, N'Áo sơ mi nam cộc tay thoáng mát, dễ phối đồ', N'98% cotton 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T22:02:04.943' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T22:02:04.943' AS DateTime), N'Nguyễn Viết Lộc', N'#5d2849   ', N'/UserImage/images/1934480679sm11.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (60, 1, N'Áo phông nam trang trí đơn giản', 199000.0000, N'Áo phông nam trang trí đơn giản khỏe khoắn', N'95% cotton 5% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T22:02:49.123' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T22:02:49.123' AS DateTime), N'Nguyễn Viết Lộc', N'#90bf22   ', N'/UserImage/images/1783691656ap9.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (61, 1, N'Áo phông nam đen', 199000.0000, N'Áo phông nam đen dễ phối đồ', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T22:03:45.553' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T22:03:45.553' AS DateTime), N'Nguyễn Viết Lộc', N'#030303   ', N'/UserImage/images/1265400483ap13.jpg')
INSERT [dbo].[SanPham] ([MaSP], [MaDM], [TenSP], [Gia], [MoTa], [ChatLieu], [HuongDan], [NgayTao], [NguoiTao], [NgaySua], [NguoiSua], [MaMau], [HinhAnh]) VALUES (62, 2, N'Áo sơ mi nam trơn', 399000.0000, N'Áo sơ mi nam trơn thanh lịch trang nhã', N'98% cotton, 2% spandex', N'Giặt máy ở nhiệt độ thường.
Không sử dụng chất tẩy.
Phơi trong bóng mát.
Sấy thùng, mức nhiệt độ trung bình.
Là ở nhiệt độ trung bình 150 độ C.
Giặt với sản phẩm cùng màu.
Không là lên chi tiết trang trí.', CAST(N'2021-08-07T22:04:40.720' AS DateTime), N'Nguyễn Viết Lộc', CAST(N'2021-08-07T22:04:40.720' AS DateTime), N'Nguyễn Viết Lộc', N'#e4d8d8   ', N'/UserImage/images/1801056870sm9.jpg')
SET IDENTITY_INSERT [dbo].[SanPham] OFF
GO
SET IDENTITY_INSERT [dbo].[SanPhamChiTiet] ON 

INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (1, 1, 1, 2)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (2, 1, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (3, 1, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (4, 1, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (5, 1, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (6, 1, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (7, 2, 1, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (8, 2, 2, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (9, 2, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (10, 2, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (11, 2, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (12, 2, 6, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (13, 3, 1, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (14, 3, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (15, 3, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (16, 3, 4, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (17, 3, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (18, 3, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (19, 4, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (20, 4, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (21, 4, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (22, 4, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (23, 4, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (24, 4, 6, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (25, 5, 1, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (26, 5, 2, 3)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (27, 5, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (28, 5, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (29, 5, 5, 3)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (30, 5, 6, 1)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (31, 6, 1, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (32, 6, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (33, 6, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (34, 6, 4, 2)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (35, 6, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (36, 6, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (37, 7, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (38, 7, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (39, 7, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (40, 7, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (41, 7, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (42, 7, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (43, 8, 1, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (44, 8, 2, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (45, 8, 3, 3)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (46, 8, 4, 13)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (47, 8, 5, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (48, 8, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (49, 9, 1, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (50, 9, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (51, 9, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (52, 9, 4, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (53, 9, 5, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (54, 9, 6, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (55, 10, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (56, 10, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (57, 10, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (58, 10, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (59, 10, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (60, 10, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (61, 11, 1, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (62, 11, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (63, 11, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (64, 11, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (65, 11, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (66, 11, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (67, 12, 1, 3)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (68, 12, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (69, 12, 3, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (70, 12, 4, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (71, 12, 5, 11)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (72, 12, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (73, 13, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (74, 13, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (75, 13, 3, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (76, 13, 4, 25)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (77, 13, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (78, 13, 6, 3)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (79, 14, 1, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (80, 14, 2, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (81, 14, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (82, 14, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (83, 14, 5, 13)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (84, 14, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (85, 15, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (86, 15, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (87, 15, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (88, 15, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (89, 15, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (90, 15, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (91, 16, 1, 3)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (92, 16, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (93, 16, 3, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (94, 16, 4, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (95, 16, 5, 11)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (96, 16, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (97, 17, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (98, 17, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (99, 17, 3, 15)
GO
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (100, 17, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (101, 17, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (102, 17, 6, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (103, 18, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (104, 18, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (105, 18, 3, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (106, 18, 4, 6)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (107, 18, 5, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (108, 18, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (109, 19, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (110, 19, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (111, 19, 3, 2)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (112, 19, 4, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (113, 19, 5, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (114, 19, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (115, 20, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (116, 20, 2, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (117, 20, 3, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (118, 20, 4, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (119, 20, 5, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (120, 20, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (121, 21, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (122, 21, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (123, 21, 3, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (124, 21, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (125, 21, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (126, 21, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (127, 22, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (128, 22, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (129, 22, 3, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (130, 22, 4, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (131, 22, 5, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (132, 22, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (133, 23, 1, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (134, 23, 2, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (135, 23, 3, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (136, 23, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (137, 23, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (138, 23, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (139, 24, 1, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (140, 24, 2, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (141, 24, 3, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (142, 24, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (143, 24, 5, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (144, 24, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (145, 25, 1, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (146, 25, 2, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (147, 25, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (148, 25, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (149, 25, 5, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (150, 25, 6, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (151, 26, 1, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (152, 26, 2, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (153, 26, 3, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (154, 26, 4, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (155, 26, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (156, 26, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (157, 27, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (158, 27, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (159, 27, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (160, 27, 4, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (161, 27, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (162, 27, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (163, 28, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (164, 28, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (165, 28, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (166, 28, 4, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (167, 28, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (168, 28, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (169, 29, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (170, 29, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (171, 29, 3, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (172, 29, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (173, 29, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (174, 29, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (175, 30, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (176, 30, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (177, 30, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (178, 30, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (179, 30, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (180, 30, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (181, 31, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (182, 31, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (183, 31, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (184, 31, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (185, 31, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (186, 31, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (187, 32, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (188, 32, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (189, 32, 3, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (190, 32, 4, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (191, 32, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (192, 32, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (193, 33, 1, 50)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (194, 33, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (195, 33, 3, 20)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (196, 33, 4, 11)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (197, 33, 5, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (198, 33, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (199, 34, 1, 5)
GO
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (200, 34, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (201, 34, 3, 11)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (202, 34, 4, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (203, 34, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (204, 34, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (205, 35, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (206, 35, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (207, 35, 3, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (208, 35, 4, 20)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (209, 35, 5, 21)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (210, 35, 6, 20)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (211, 36, 1, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (212, 36, 2, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (213, 36, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (214, 36, 4, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (215, 36, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (216, 36, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (217, 37, 1, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (218, 37, 2, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (219, 37, 3, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (220, 37, 4, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (221, 37, 5, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (222, 37, 6, 6)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (223, 38, 1, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (224, 38, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (225, 38, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (226, 38, 4, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (227, 38, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (228, 38, 6, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (229, 39, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (230, 39, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (231, 39, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (232, 39, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (233, 39, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (234, 39, 6, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (235, 40, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (236, 40, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (237, 40, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (238, 40, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (239, 40, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (240, 40, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (241, 41, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (242, 41, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (243, 41, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (244, 41, 4, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (245, 41, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (246, 41, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (247, 42, 1, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (248, 42, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (249, 42, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (250, 42, 4, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (251, 42, 5, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (252, 42, 6, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (253, 43, 1, 3)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (254, 43, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (255, 43, 3, 14)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (256, 43, 4, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (257, 43, 5, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (258, 43, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (259, 44, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (260, 44, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (261, 44, 3, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (262, 44, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (263, 44, 5, 2)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (264, 44, 6, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (265, 45, 1, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (266, 45, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (267, 45, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (268, 45, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (269, 45, 5, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (270, 45, 6, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (271, 46, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (272, 46, 2, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (273, 46, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (274, 46, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (275, 46, 5, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (276, 46, 6, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (277, 47, 1, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (278, 47, 2, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (279, 47, 3, 4)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (280, 47, 4, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (281, 47, 5, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (282, 47, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (283, 48, 1, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (284, 48, 2, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (285, 48, 3, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (286, 48, 4, 7)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (287, 48, 5, 8)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (288, 48, 6, 9)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (289, 49, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (290, 49, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (291, 49, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (292, 49, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (293, 49, 5, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (294, 49, 6, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (295, 50, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (296, 50, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (297, 50, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (298, 50, 4, 14)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (299, 50, 5, 16)
GO
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (300, 50, 6, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (301, 51, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (302, 51, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (303, 51, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (304, 51, 4, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (305, 51, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (306, 51, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (307, 52, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (308, 52, 2, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (309, 52, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (310, 52, 4, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (311, 52, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (312, 52, 6, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (313, 53, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (314, 53, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (315, 53, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (316, 53, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (317, 53, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (318, 53, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (319, 54, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (320, 54, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (321, 54, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (322, 54, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (323, 54, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (324, 54, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (325, 55, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (326, 55, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (327, 55, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (328, 55, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (329, 55, 5, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (330, 55, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (331, 56, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (332, 56, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (333, 56, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (334, 56, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (335, 56, 5, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (336, 56, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (337, 57, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (338, 57, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (339, 57, 3, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (340, 57, 4, 151)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (341, 57, 5, 16)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (342, 57, 6, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (343, 58, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (344, 58, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (345, 58, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (346, 58, 4, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (347, 58, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (348, 58, 6, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (349, 59, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (350, 59, 2, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (351, 59, 3, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (352, 59, 4, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (353, 59, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (354, 59, 6, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (355, 60, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (356, 60, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (357, 60, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (358, 60, 4, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (359, 60, 5, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (360, 60, 6, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (361, 61, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (362, 61, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (363, 61, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (364, 61, 4, 15)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (365, 61, 5, 12)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (366, 61, 6, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (367, 62, 1, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (368, 62, 2, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (369, 62, 3, 5)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (370, 62, 4, 0)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (371, 62, 5, 10)
INSERT [dbo].[SanPhamChiTiet] ([IDCTSP], [MaSP], [MaKichCo], [SoLuong]) VALUES (372, 62, 6, 0)
SET IDENTITY_INSERT [dbo].[SanPhamChiTiet] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__DanhMuc__650CAE4E6292B603]    Script Date: 11/19/2024 8:56:45 PM ******/
ALTER TABLE [dbo].[DanhMuc] ADD UNIQUE NONCLUSTERED 
(
	[TenDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__DanhMuc__650CAE4E76F5A823]    Script Date: 11/19/2024 8:56:45 PM ******/
ALTER TABLE [dbo].[DanhMuc] ADD UNIQUE NONCLUSTERED 
(
	[TenDanhMuc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([IDCTSP])
REFERENCES [dbo].[SanPhamChiTiet] ([IDCTSP])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ChiTietHoaDon]  WITH CHECK ADD FOREIGN KEY([MaHD])
REFERENCES [dbo].[HoaDon] ([MaHD])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD FOREIGN KEY([MaTK])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD FOREIGN KEY([MaDM])
REFERENCES [dbo].[DanhMuc] ([MaDM])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhamChiTiet]  WITH CHECK ADD FOREIGN KEY([MaKichCo])
REFERENCES [dbo].[KichCo] ([MaKichCo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPhamChiTiet]  WITH CHECK ADD FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
