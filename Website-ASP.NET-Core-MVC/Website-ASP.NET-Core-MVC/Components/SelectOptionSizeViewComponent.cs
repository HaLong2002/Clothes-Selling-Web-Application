using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Components
{
	public class SelectOptionSizeViewComponent : ViewComponent
	{
		private readonly ApplicationDbContext _context;

		public SelectOptionSizeViewComponent(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IViewComponentResult> InvokeAsync()		
		{
			IEnumerable<KichCo> kichCos = _context.KichCoes.Select(p => p);
			return View(kichCos);
		}
	}
}
