using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Profiles
{
    public class EditProModel : PageModel
    {
        private readonly ICustomerService _service;
        public EditProModel(ICustomerService service)
        {
            _service = service;
        }
        [BindProperty]
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
                return RedirectToPage("/Index");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Cập nhật thông tin khách hàng
            var customerId = HttpContext.Session.GetString("CustomerId");
            if (customerId != Customer.CustomerId)
            {
                return Forbid();
            }

            bool updated = await _service.UpdateCustomerAsync(Customer);
            if (!updated)
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi cập nhật thông tin. Vui lòng thử lại.");
                return Page();
            }

            // Chuyển hướng đến trang chi tiết sau khi cập nhật thành công
            return RedirectToPage("/Profiles/DetailsPro");
        }
    }
}

