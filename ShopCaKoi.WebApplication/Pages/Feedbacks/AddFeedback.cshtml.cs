using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Feedbacks
{
    public class AddFeedbackModel : PageModel
    {
        private readonly IFeedbackService _feedbackService;

        public AddFeedbackModel(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [BindProperty]
        public Feedback Feedback { get; set; } = new Feedback();

        public IActionResult OnGet()
        {
            // Kiểm tra xem người dùng đã đăng nhập chưa
            var customerId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToPage("/Profiles/LogIn"); // Chuyển hướng đến trang đăng nhập nếu chưa đăng nhập
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            var customerId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToPage("/Profiles/LogIn"); // Chuyển hướng đến trang đăng nhập nếu chưa đăng nhập
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Feedback.Id = Guid.NewGuid().ToString();

            // Gắn CustomerId vào Feedback
            Feedback.CustomerId = customerId;

            // Thêm phản hồi
            bool isAdded = _feedbackService.AddFeedback(Feedback);
            if (!isAdded)
            {
                ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi thêm phản hồi.");
                return Page();
            }

            TempData["SuccessMessage"] = "Phản hồi của bạn đã được gửi thành công.";
            return RedirectToPage("/Feedbacks/Success");
        }
    }
}
