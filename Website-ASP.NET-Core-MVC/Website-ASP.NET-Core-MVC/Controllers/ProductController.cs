using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;

namespace Website_ASP.NET_Core_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
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
            List<SanPhamChiTiet> list = _context.SanPhamChiTiets.Include("KichCo").Where(s => s.MaSP.Equals(id)).ToList();
            ViewBag.SPCT = list;
            ViewBag.Exitst = list[0];
            return View(sp);
        }
     
        [HttpPost]
        public JsonResult Index(int id)
        {
            SanPham sp = _context.SanPhams
                                 .Include(s => s.DanhMuc)
                                 .Include(s => s.SanPhamChiTiets)
                                 .FirstOrDefault(s => s.MaSP == id);

            return Json(sp);
        }


        [HttpPost]
        public JsonResult Detail(int id)
        {
            SanPhamChiTiet spct = _context.SanPhamChiTiets.Where(sp => sp.IDCTSP == id).FirstOrDefault();
            return Json(spct);
        }
    }
}
