using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ShopCaKoi.WebApplication.Pages.Profiles
{
    public class LogOutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // Xóa session của khách hàng
            HttpContext.Session.Remove("CustomerName");

            // Chuyển hướng tới trang chính hoặc trang đăng nhập
            return RedirectToPage("/Index");
        }
    }
}
