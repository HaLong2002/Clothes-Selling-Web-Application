﻿using System.ComponentModel.DataAnnotations;

namespace Website_ASP.NET_Core_MVC.ViewModels
{
	public class VerifyEmailViewModel
	{
		[Required(ErrorMessage = "Vui lòng nhập email")]
		[EmailAddress]
		public string Email { get; set; }
	}
}
