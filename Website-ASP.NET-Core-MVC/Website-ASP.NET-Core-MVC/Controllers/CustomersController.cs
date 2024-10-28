using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Helpers;
using Website_ASP.NET_Core_MVC.Models;
using Website_ASP.NET_Core_MVC.ViewModels;

namespace Website_ASP.NET_Core_MVC.Controllers
{
	public class CustomersController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public CustomersController(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		// GET: Customers
		public async Task<IActionResult> Index()
		{
			return View(await _context.Customers.ToListAsync());
		}

		// GET: Customers/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers
				.FirstOrDefaultAsync(m => m.Id == id);
			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}

		// GET: Customers/SignUp
		public IActionResult SignUp()
		{
			return View();
		}

		// API endpoint to check for unique username
		[HttpGet]
		public async Task<JsonResult> IsUsernameAvailable(string username)
		{
			bool isAvailable = !await _context.Customers.AnyAsync(u => u.UserName == username);
			return Json(isAvailable);
		}

		// API endpoint to check for unique email
		[HttpGet]
		public async Task<JsonResult> IsEmailAvailable(string email)
		{
			bool isAvailable = !await _context.Customers.AnyAsync(u => u.Email == email);
			return Json(isAvailable);
		}

		// POST: Customers/SignUp
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SignUp(CustomerViewModel customerViewModel)
		{
			if (ModelState.IsValid)
			{
				// Map ViewModel to Model
				var customer = _mapper.Map<Customer>(customerViewModel);

				// Mã hóa mật khẩu
				string randomKey = MyUtil.GenerateRandomKey();
				customer.Password = customerViewModel.Password.ToMd5Hash(randomKey);

				customer.IsValid = true;

				// If both checks pass, save the user
				_context.Add(customer);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(customerViewModel);
		}

		// GET: Customers/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers.FindAsync(id);
			if (customer == null)
			{
				return NotFound();
			}
			return View(customer);
		}

		// POST: Customers/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("Id,UserName,Email,Password,Phone,FullName,Gender,Date,Address")] Customer customer)
		{
			if (id != customer.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(customer);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CustomerExists(customer.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(customer);
		}

		// GET: Customers/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var customer = await _context.Customers
				.FirstOrDefaultAsync(m => m.Id == id);
			if (customer == null)
			{
				return NotFound();
			}

			return View(customer);
		}

		// POST: Customers/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var customer = await _context.Customers.FindAsync(id);
			if (customer != null)
			{
				_context.Customers.Remove(customer);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CustomerExists(int id)
		{
			return _context.Customers.Any(e => e.Id == id);
		}
	}
}
