using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;
using X.PagedList.Extensions;

namespace Website_ASP.NET_Core_MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin,SuperAdmin")]
    public class CategoryController : Controller
	{
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CategoryController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public ActionResult Index(string searchString, int page = 1, int pageSize = 5)
        {
            ViewBag.searchString = searchString;
            var danhmucs = _context.DanhMucs.Select(dm => dm);
            if (!String.IsNullOrEmpty(searchString))
            {
                danhmucs = danhmucs.Where(dm => dm.TenDanhMuc.Contains(searchString));
            }
            return View(danhmucs.OrderBy(dm => dm.MaDM).ToPagedList(page, pageSize));
        }

        [HttpPost]
        public JsonResult Index(int id)
        {
            DanhMuc dm = _context.DanhMucs.Where(a => a.MaDM.Equals(id)).FirstOrDefault();
            return Json(dm);
        }

        [HttpPost]
        public async Task<JsonResult> Create([FromBody] DanhMuc dm)
        {
            if(dm.TenDanhMuc == null)
            {
                return Json(new { status = false, message = "Tên danh mục rỗng" });
            }

            var tk = await _userManager.GetUserAsync(User);
            try
            {
                dm.NgayTao = DateTime.Now;
                dm.NguoiTao = tk.FullName;
                dm.NgaySua = DateTime.Now;
                dm.NguoiSua = tk.FullName;
                _context.DanhMucs.Add(dm);
                _context.SaveChanges();
                return Json(new { status = true, message = "Thêm thành công" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Tên danh mục đã tồn tại" });
            }
        }

        [HttpPost]
        public async Task<JsonResult> Update([FromBody] DanhMuc dm)
        {
            //TaiKhoanQuanTri tk = (TaiKhoanQuanTri)Session[Nhom9.Session.ConstaintUser.ADMIN_SESSION];
            var tk = await _userManager.GetUserAsync(User);
            try
            {
                DanhMuc update = _context.DanhMucs.Where(a => a.MaDM.Equals(dm.MaDM)).FirstOrDefault();
                update.TenDanhMuc = dm.TenDanhMuc;
                update.NgaySua = DateTime.Now;
                update.NguoiSua = tk.FullName;
                _context.Entry(update).State = EntityState.Modified;
                _context.SaveChanges();
                return Json(new { status = true, message = "Sửa thông tin thành công" });
            }
            catch (Exception)
            {
                return Json(new { status = false, message = "Tên danh mục đã tồn tại" });
            }
        }

        [HttpPost]
        public JsonResult Delete(int id)
        {
            try
            {
                DanhMuc dm = _context.DanhMucs.Where(a => a.MaDM.Equals(id)).FirstOrDefault();
                _context.DanhMucs.Remove(dm);
                _context.SaveChanges();
                return Json(new { status = true });
            }
            catch (Exception)
            {
                return Json(new { status = false });
            }
        }
    }
}
