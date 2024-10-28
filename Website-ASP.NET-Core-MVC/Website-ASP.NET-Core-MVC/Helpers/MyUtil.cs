using System.Text;

namespace Website_ASP.NET_Core_MVC.Helpers
{
	public class MyUtil
	{
		public static string UploadImage(IFormFile image,  string folder)
		{
			try
			{
				var fullPath = Path.Combine
					(Directory.GetCurrentDirectory(), "wwwroot", "Images", folder, image.FileName);
				using (var myfile = new FileStream(fullPath, FileMode.CreateNew))
				{
					image.CopyTo(myfile);
				}

				return image.FileName;
			}
			catch (Exception ex)
			{
				return string.Empty;
			}

		}

		public static string GenerateRandomKey(int length = 5)
		{
			var pattern = @"qazxswedcvfrtgbnhyujmkiolpQAZXSWEDCVFRTGBNHYUJMKILOP!@#$%*&^";
			var sb = new StringBuilder();
			var rd = new Random();
			for (int i = 0; i < length; i++)
			{
				sb.Append(pattern[rd.Next(0, pattern.Length)]);
			}

			return sb.ToString();
		}
	}
}
