﻿namespace Website_ASP.NET_Core_MVC.Areas.Admin.Models
{
	public class CreateAccountClient
	{
		public string FullName { get; set; }
		public string Email { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Address { get; set; }
		public DateTime? Date { get; set; }
		public string? Gender { get; set; }
		public string Password { get; set; }
		public string ConfirmPassword { get; set; }
	}
}