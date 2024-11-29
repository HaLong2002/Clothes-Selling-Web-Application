using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using System.Text.Json;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin,Sale")]
    public class ProductController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly UserManager<User> _userManager;
		private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ILogger<ProductController> _logger;

		public ProductController(ApplicationDbContext context, UserManager<User> userManager, IWebHostEnvironment webHostEnvironment, ILogger<ProductController> logger)
		{
			_context = context;
			_userManager = userManager;
			_webHostEnvironment = webHostEnvironment;
			_logger = logger;
		}

		// GET: Admin/Product
		[HttpGet]
		public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
		{
			ViewBag.Category = _context.DanhMucs.Select(d => d);
			ViewBag.Size = _context.KichCoes.Select(c => c);
			ViewBag.searchString = searchString;
			var sanphams = _context.SanPhams.Include("DanhMuc").Select(p => p);
			if (!String.IsNullOrEmpty(searchString))
			{
				sanphams = sanphams.Where(sp => sp.TenSP.Contains(searchString));
			}
			return View(sanphams.OrderBy(sp => sp.MaSP).ToPagedList(page, pageSize));
		}

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
		public async Task<JsonResult> Create(string sanpham, string chiTiets, /*HttpPostedFileBase hinhanh*/ IFormFile hinhanh)
		{
			try
			{
				SanPham sp = JsonSerializer.Deserialize<SanPham>(sanpham);
                List<SanPhamChiTiet> sanPhamChiTiets = JsonSerializer.Deserialize<List<SanPhamChiTiet>>(chiTiets);

                var tk = await _userManager.GetUserAsync(User);
				
				var f = hinhanh;
				if (f != null)
				{
					string fileName = new Random().Next() + f.FileName;
					var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UserImage/images");
					var uploadPath = Path.Combine(uploadsFolder, fileName);

					using (var fileStream = new FileStream(uploadPath, FileMode.Create))
					{
						await f.CopyToAsync(fileStream);
					}

					sp.HinhAnh = "/UserImage/images/" + fileName;
				}
				else
				{
					sp.HinhAnh = "/UserImage/images/noimage.jpg";
				}
				sp.NgayTao = DateTime.Now;
				sp.NguoiTao = tk.FullName;
				sp.NgaySua = DateTime.Now;
				sp.NguoiSua = tk.FullName;
				_context.SanPhams.Add(sp);
				_context.SaveChanges();
				int masp = sp.MaSP;

                foreach (SanPhamChiTiet spct in sanPhamChiTiets)
				{
                    if (!_context.KichCoes.Any(k => k.MaKichCo == spct.MaKichCo))
                    {
                        return Json(new { status = false, message = $"Kích cỡ không hợp lệ: {spct.MaKichCo}" });
                    }
                    spct.MaSP = masp;
					_context.SanPhamChiTiets.Add(spct);
					_context.SaveChanges();
                }
                return Json(new { status = true, message = "Thêm thành công!" });
			}
			catch (Exception ex)
			{
				return Json(new { status = false, message = "Thêm không thành công!", error = ex.Message });
			}
		}

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
		public async Task<JsonResult> Update(string sanpham, string chiTiets, IFormFile hinhanh)
		{
			try
			{
				SanPham sp = JsonSerializer.Deserialize<SanPham>(sanpham);
				List<SanPhamChiTiet> sanPhamChiTiets = JsonSerializer.Deserialize<List<SanPhamChiTiet>>(chiTiets);

				//TaiKhoanQuanTri tk = (TaiKhoanQuanTri)Session[Nhom9.Session.ConstaintUser.ADMIN_SESSION];
				var tk = await _userManager.GetUserAsync(User);

				SanPham update = _context.SanPhams.Where(u => u.MaSP.Equals(sp.MaSP)).FirstOrDefault();
                if (update == null)
                {
                    return Json(new { status = false, message = "Sản phẩm không tồn tại." });
                }
                var f = hinhanh;
				if (f != null)
				{
					string fileName = new Random().Next() + f.FileName;
					var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "UserImage/images");
					var uploadPath = Path.Combine(uploadsFolder, fileName);

					using (var fileStream = new FileStream(uploadPath, FileMode.Create))
					{
						await f.CopyToAsync(fileStream);
					}
					//f.SaveAs(uploadPath);
					update.HinhAnh = "/UserImage/images/" + fileName;
				}
				update.MaDM = sp.MaDM;
				update.TenSP = sp.TenSP;
				update.Gia = sp.Gia;
				update.MoTa = sp.MoTa;
				update.MaMau = sp.MaMau;
				update.ChatLieu = sp.ChatLieu;
				update.HuongDan = sp.HuongDan;
				update.NgaySua = DateTime.Now;
				update.NguoiSua = tk.FullName;
				_context.Entry(update).State = EntityState.Modified;
				_context.SaveChanges();
				foreach (SanPhamChiTiet spct in sanPhamChiTiets)
				{
					SanPhamChiTiet updatee = _context.SanPhamChiTiets.Where(u => u.IDCTSP.Equals(spct.IDCTSP)).FirstOrDefault();
					updatee.SoLuong = spct.SoLuong;
					_context.Entry(updatee).State = EntityState.Modified;
					_context.SaveChanges();
				}
				return Json(new { status = true, message = "Sửa thông tin thành công!" });
			}
			catch (Exception ex)
			{
				return Json(new { status = false, message = "Sửa thông tin không thành công!" + ex.Message });
			}
		}

        [Authorize(Roles = "Admin,SuperAdmin")]
        [HttpPost]
		public JsonResult Delete(int id)
		{
			try
			{
				SanPham sp = _context.SanPhams.Where(a => a.MaSP.Equals(id)).FirstOrDefault();
				_context.SanPhams.Remove(sp);
				_context.SaveChanges();
				return Json(new { status = true });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return Json(new { status = false });
			}
		}

		[HttpPost]
		public JsonResult Index(int id)
		{
			SanPham sp = _context.SanPhams.Include("SanPhamChiTiets").Include("DanhMuc").Where(s => s.MaSP.Equals(id)).FirstOrDefault();

            var productViewModel = new
            {
                sp.MaSP,
                sp.MaDM,
                sp.TenSP,
                sp.Gia,
                sp.MoTa,
                sp.ChatLieu,
                sp.HuongDan,
                sp.NgayTao,
                sp.NguoiTao,
                sp.NgaySua,
                sp.NguoiSua,
                sp.MaMau,
                sp.HinhAnh,
                DanhMuc = new
                {
                    sp.DanhMuc.MaDM,
                    sp.DanhMuc.TenDanhMuc,
                    sp.DanhMuc.NgayTao,
                    sp.DanhMuc.NguoiTao,
                    sp.DanhMuc.NgaySua,
                    sp.DanhMuc.NguoiSua
                },
                SanPhamChiTiets = sp.SanPhamChiTiets.Select(sct => new
                {
                    sct.IDCTSP,
                    sct.MaKichCo,
                    sct.SoLuong
                }).ToList()
            };

            return Json(productViewModel);
		}
	}
}
