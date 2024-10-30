using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Website_ASP.NET_Core_MVC.Data;
using Website_ASP.NET_Core_MVC.Helpers;
using Website_ASP.NET_Core_MVC.Models;
using Website_ASP.NET_Core_MVC.ViewModels;

namespace Website_ASP.NET_Core_MVC.Controllers
{
	public class UserController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;
		private readonly IEmailSender _emailSender;
		private readonly UserManager<User> _userManager;

		public UserController(ApplicationDbContext context, IMapper mapper, IEmailSender emailSender, UserManager<User> userManager)
		{
			_context = context;
			_mapper = mapper;
			_emailSender = emailSender;
			_userManager = userManager;
		}

		// GET: Customers/SignUp
		public IActionResult SignUp()
		{
			var model = new RegisterViewModel
			{
				GenderOptions = new List<SelectListItem>
				{
					new SelectListItem { Value = "Nữ", Text = "Nữ" },
					new SelectListItem { Value = "Nam", Text = "Nam" },
					new SelectListItem { Value = "Khác", Text = "Khác" }
				}
			};

			return View(model);
		}
		
		// API endpoint to check for unique username
		//[HttpGet]
		//public async Task<JsonResult> IsUsernameAvailable(string username)
		//{
		//	bool isAvailable = !await _context.Customers.AnyAsync(u => u.UserName == username);
		//	return Json(isAvailable);
		//}

		//// API endpoint to check for unique email
		//[HttpGet]
		//public async Task<JsonResult> IsEmailAvailable(string email)
		//{
		//	bool isAvailable = !await _context.Customers.AnyAsync(u => u.Email == email);
		//	return Json(isAvailable);
		//}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> SignUp(RegisterViewModel customerViewModel)
		{
			if (ModelState.IsValid)
			{
				customerViewModel.Name = customerViewModel.Name.Trim();

				// Map ViewModel to Model
				var customer = _mapper.Map<User>(customerViewModel);

				/*
				// Mã hóa mật khẩu
				string randomKey = MyUtil.GenerateRandomKey();
				customer.Password = customerViewModel.Password.ToMd5Hash(randomKey);

				// Gửi email cho người dùng để xác nhận
				//customer.IsValid = false;
				//var random = new Random();
				//string code = random.Next(100000, 1000000).ToString();
				//string subject = code + " là mã xác minh DDDK của bạn";
				string messageBody = EmailMessageBody(code);
				await _emailSender.SendEmailAsync(customer.Email, subject, messageBody);

				// If both checks pass, save the user
				_context.Add(customer);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
				*/
				// Use UserManager to create the user with password hashing

				var result = await _userManager.CreateAsync(customer, customerViewModel.Password);

				if (result.Succeeded)
				{
					// Generate a confirmation token
					var token = await _userManager.GenerateEmailConfirmationTokenAsync(customer);

					// Create the confirmation link
					var confirmationLink = Url.Action("ConfirmEmail", "Customers", new { userId = customer.Id, token }, Request.Scheme);

					// Prepare the email message
					string subject = "Email Confirmation";
					string messageBody = $"Please confirm your email by clicking this link: <a href='{confirmationLink}'>Confirm Email</a>";

					// Send confirmation email
					await _emailSender.SendEmailAsync(customer.Email, subject, messageBody);

					return RedirectToAction(nameof(Index));
				}

				// Handle creation errors
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(string.Empty, error.Description);
				}
			}
			return View(customerViewModel);
		}

		private string EmailMessageBody(string code)
		{
			string messageBody = $@"
				<!DOCTYPE html>
				<html>
				<head>
					<style>
						.message {{
							font-size: 16px;
							margin-top: 10px;
						}}
						.code {{
							font-size: 32px;
							font-weight: bold;
							margin-top: 20px;
						}}
					</style>
				</head>
				<body>
					<p class='message'>Nhập mã này trong vòng 10 phút để hoàn tất quá trình đăng ký:</p>
					<p class='code'>{code}</p>
				</body>
				</html>
				";

			return messageBody;
		}

		// GET: Customers/SignUp
		public IActionResult ConfirmEmail()
		{
			return View();
		}

		
	}
}
