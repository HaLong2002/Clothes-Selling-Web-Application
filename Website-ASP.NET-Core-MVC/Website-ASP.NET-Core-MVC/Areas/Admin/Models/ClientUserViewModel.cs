namespace Website_ASP.NET_Core_MVC.Areas.Admin.Models
{
    public class ClientUserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public DateTime? Date { get; set; }
        public string? Gender { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string? ExistingImage { get; set; }
        public bool LockoutStatus { get; set; }

    }
}
