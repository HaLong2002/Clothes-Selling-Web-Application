using AutoMapper;
using Website_ASP.NET_Core_MVC.Models;
using Website_ASP.NET_Core_MVC.ViewModels;

namespace Website_ASP.NET_Core_MVC.Helpers
{
	public class AutoMapperCustomer : Profile
	{
		public AutoMapperCustomer()
		{
			CreateMap<CustomerViewModel, Customer>();
		}
	}
}
