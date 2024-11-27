using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;

namespace Website_ASP.NET_Core_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ApplicationDbContext _context;

        public ProductController(ILogger<ProductController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }        

        public ActionResult Shop(string searchString, int? madm, int page = 1, int pageSize = 9)
        {
            ViewBag.searchString = searchString;
            ViewBag.madm = madm;
            var sanphams = _context.SanPhams.Select(p => p);
            if (!String.IsNullOrEmpty(searchString))
            {
                sanphams = sanphams.Where(sp => sp.TenSP.Contains(searchString));
            }
            if (madm != null && madm != 0)
            {
                sanphams = sanphams.Where(s => s.MaDM == madm);
                ViewBag.DanhMuc = _context.DanhMucs.Where(d => d.MaDM == madm).FirstOrDefault();
            }
            return View(sanphams.OrderBy(sp => sp.MaSP).ToPagedList(page, pageSize));
        }

        public ActionResult ProductDetail(int id)
        {
            SanPham sp = _context.SanPhams.Include("DanhMuc").Where(s => s.MaSP.Equals(id)).FirstOrDefault();
			List<SanPhamChiTiet> list = _context.SanPhamChiTiets
				.Include(spct => spct.KichCo)
				.Where(s => s.MaSP == id)
				.ToList();
			ViewBag.SPCT = list;
            ViewBag.Exitst = list[0];
            return View(sp);
        }

        [HttpPost]
        public JsonResult Index(int id)
        {
            try
            {
                var sp = _context.SanPhams
                                .Include(s => s.DanhMuc)
                                .Include(s => s.SanPhamChiTiets)
                                .FirstOrDefault(s => s.MaSP == id);

                if (sp == null)
                {
                    _logger.LogWarning($"Không tìm thấy sản phẩm với ID: {id}");
                    return Json(new { error = "Không tìm thấy sản phẩm" });
                }

                // Prepare a simpler model to return as JSON, avoiding circular references
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

                _logger.LogInformation($"Đã tải sản phẩm ID: {id}, MaDM: {sp.MaDM}");
                return Json(productViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Lỗi khi tải sản phẩm ID {id}: {ex.Message}");
                return Json(new { error = "Có lỗi xảy ra" });
            }
        }

        [HttpPost]
        public JsonResult Detail(int id)
        {
            SanPhamChiTiet spct = _context.SanPhamChiTiets.Where(sp => sp.IDCTSP == id).FirstOrDefault();
            return Json(spct);
        }
    }
}
