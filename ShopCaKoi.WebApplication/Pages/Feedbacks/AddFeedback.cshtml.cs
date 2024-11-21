using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Feedbacks
{
    public class AddFeedbackModel : PageModel
    {
        private readonly IFeedbackService _feedbackService; // Service xử lý feedback

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

            return Page(); // Hiển thị trang thêm phản hồi
        }

        public IActionResult OnPost()
        {
            // Kiểm tra thông tin CustomerId từ session
            var customerId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToPage("/Profiles/LogIn"); // Chuyển hướng đến trang đăng nhập nếu chưa đăng nhập
            }

            // Kiểm tra tính hợp lệ của dữ liệu
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Thiết lập thông tin cho Feedback
            Feedback.Id = Guid.NewGuid().ToString(); // Tạo ID duy nhất
            Feedback.CustomerId = customerId;        // Lấy CustomerId từ session
              // Gắn ngày tạo (UTC)

            try
            {
                // Gọi service để lưu phản hồi
                var isAdded = _feedbackService.AddFeedback(Feedback);
                if (!isAdded)
                {
                    ModelState.AddModelError(string.Empty, "Đã xảy ra lỗi khi thêm phản hồi.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và ghi log nếu cần
                ModelState.AddModelError(string.Empty, $"Lỗi: {ex.Message}");
                return Page();
            }

            // Gửi thông báo thành công và chuyển hướng
            TempData["SuccessMessage"] = "Phản hồi của bạn đã được gửi thành công.";
            return RedirectToPage("/Feedbacks/Success");
        }
    }
}
