using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Profiles
{
    public class DetailsProModel : PageModel
    {
        private readonly ICustomerService _service;
        public DetailsProModel(ICustomerService service)
        {
            _service = service;
        }

        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy CustomerId từ session
            var customerId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerId))
            {
                // Nếu không có trong session, chuyển hướng đến trang đăng nhập
                return RedirectToPage("/Log/Login");
            }

            // Tải thông tin khách hàng theo CustomerId
            Customer = await _service.GetCustomerByIdAsync(customerId);
            if (Customer == null)
            {
                // Nếu không tìm thấy khách hàng, chuyển hướng đến trang lỗi hoặc trang chính
                return RedirectToPage("/Index");
            }

            return Page();
        }
    }
}
