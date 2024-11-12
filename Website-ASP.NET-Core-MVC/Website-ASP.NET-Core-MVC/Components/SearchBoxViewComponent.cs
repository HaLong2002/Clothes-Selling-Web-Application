using Microsoft.AspNetCore.Mvc;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Components
{
	public class SearchBoxViewComponent : ViewComponent
	{
		private readonly ApplicationDbContext _context;

		public SearchBoxViewComponent(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			IEnumerable<DanhMuc> danhmucs = _context.DanhMucs.Select(p => p);
			return View(danhmucs);
		}
	}
}
