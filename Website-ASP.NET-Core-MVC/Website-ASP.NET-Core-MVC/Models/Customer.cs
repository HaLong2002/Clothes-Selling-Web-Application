﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Website_ASP.NET_Core_MVC.Models
{
    public class Customer : IdentityUser<int>
	{
        public int Id { get; set; }
		public string UserName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string Phone { get; set; }
		public string FullName { get; set; }
		public string? Gender { get; set; }

		[DataType(DataType.Date)]
		[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
		public DateTime? Date { get; set; }
		public string Address { get; set; }
		public string? Image { get; set; }
		public bool IsValid { get; set; } = false;
    }
}
