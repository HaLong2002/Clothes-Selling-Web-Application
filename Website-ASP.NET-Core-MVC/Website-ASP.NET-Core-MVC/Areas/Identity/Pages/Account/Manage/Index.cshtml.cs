// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Website_ASP.NET_Core_MVC.Models;

namespace Website_ASP.NET_Core_MVC.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public IndexModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            IWebHostEnvironment webHostEnvironment)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public string Email { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Vui lòng nhập tên của bạn")]
            [MaxLength(20, ErrorMessage = "Tối đa 20 kí tự")]
            [Display(Name = "Tên")]
            public string FullName { get; set; }

            [Display(Name = "Giới tính")]
            public string? Gender { get; set; }

            [DataType(DataType.Date)]
            [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")] // Change format to yyyy-MM-dd
            [Display(Name = "Ngày sinh")]
            public DateTime? Date { get; set; }

            [Display(Name = "Địa chỉ")]
            public string? Address { get; set; }

            [Phone]
            [Display(Name = "Số điện thoại")]
            public string? PhoneNumber { get; set; }

            [Display(Name = "Ảnh đại diện")]
            [DataType(DataType.Upload)]
            [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
            public IFormFile? ImageFile { get; set; }

            public string? ExistingImage { get; set; }  // To store existing image path
        }

        // Custom validation attribute for file extensions
        public class AllowedExtensionsAttribute : ValidationAttribute
        {
            private readonly string[] _extensions;
            public AllowedExtensionsAttribute(string[] extensions)
            {
                _extensions = extensions;
            }

            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value is IFormFile file)
                {
                    var extension = Path.GetExtension(file.FileName);
                    if (!_extensions.Contains(extension.ToLower()))
                    {
                        return new ValidationResult($"Chỉ cho phép các file có định dạng: {string.Join(", ", _extensions)}");
                    }
                }
                return ValidationResult.Success;
            }
        }

        private async Task LoadAsync(User user)
        {
            var email = await _userManager.GetEmailAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);

            Email = email;

            Input = new InputModel
            {
				FullName = user.FullName,
				Gender = user.Gender,
				Date = user.Date,
				Address = user.Address,
                ExistingImage = user.Image,  // Load existing image path

                PhoneNumber = phoneNumber
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Không thể tải người dùng với ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Không thể tải người dùng với ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            // Handle image upload
            if (Input.ImageFile != null)
            {
                var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images/CustomerAvatars");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                // Delete old image if exists
                if (!string.IsNullOrEmpty(user.Image))
                {
                    var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, user.Image.TrimStart('/'));
                    if (System.IO.File.Exists(oldImagePath))
                    {
                        System.IO.File.Delete(oldImagePath);
                    }
                }

                // Save new image
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + Input.ImageFile.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await Input.ImageFile.CopyToAsync(fileStream);
                }

                user.Image = "/Images/CustomerAvatars/" + uniqueFileName;
            }

            // Update basic user information
            user.FullName = Input.FullName;
            user.Gender = Input.Gender;
            user.Date = Input.Date;
            user.Address = Input.Address;
            
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Lỗi không mong muốn khi cố gắng thiết lập số điện thoại.";
                    return RedirectToPage();
                }
            }

            // Save all changes to user
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                StatusMessage = "Lỗi không mong muốn khi cập nhật thông tin người dùng.";
                return RedirectToPage();
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Hồ sơ của bạn đã được cập nhật.";
            return RedirectToPage();
        }
    }
}
