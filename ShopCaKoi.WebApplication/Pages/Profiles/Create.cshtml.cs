using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Profiles
{
    public class CreateModel : PageModel
    {
        private readonly ICustomerService _service;

        public CreateModel(ICustomerService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Customer Customer { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
			Customer.CustomerId = Guid.NewGuid().ToString();
			bool isExists = await _service.CustomerExists(Customer.CustomerId, Customer.Email);
            if (isExists)
            {
                ModelState.AddModelError(string.Empty, "Email hoặc ID đã tồn tại.");
                return Page();
            }

            bool isAdded = _service.AddCustomer(Customer);
            if (!isAdded)
            {
                ModelState.AddModelError(string.Empty, "Lỗi khi thêm . Vui lòng thử lại.");
                return Page();
            }
            TempData["SuccessMessage"] = "Đăng ký thành công! Bạn sẽ được chuyển hướng về trang chủ.";
            return RedirectToPage("/Profiles/Suscess");

        }
    }
}
