namespace Website_ASP.NET_Core_MVC.Areas.Admin.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string LockoutStatus { get; set; }
		public IEnumerable<string> Roles { get; set; }

	}

}
