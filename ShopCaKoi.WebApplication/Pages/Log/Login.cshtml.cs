using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Log
{
	public class LoginModel : PageModel
	{
		private readonly ICustomerService _service;

		public LoginModel(ICustomerService service)
		{
			_service = service;
		}

		[BindProperty]
		public string Email { get; set; }

		[BindProperty]
		public string Password { get; set; }

		[BindProperty]
		public bool RememberMe { get; set; }

		public string ErrorMessage { get; private set; }

		public async Task<IActionResult> OnPostAsync()
		{
			// Kiểm tra đầu vào
			if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
			{
				ErrorMessage = "Vui lòng nhập đầy đủ thông tin.";
				return Page();
			}

			// Lấy thông tin khách hàng theo email
			var customer = await _service.GetCustomerByEmail(Email);
			if (customer == null || customer.CustomerPassword != Password)
			{
				ErrorMessage = "Email hoặc mật khẩu không đúng.";
				return Page();
			}
			
			// Lưu thông tin tên người dùng vào session
			HttpContext.Session.SetString("CustomerName", customer.Name);
			HttpContext.Session.SetString("CustomerId", customer.CustomerId);

			// Điều hướng đến trang chủ hoặc trang mong muốn sau khi đăng nhập thành công
			return RedirectToPage("/Index");
		}
		
	}
}
