using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Sevices.Interfaces;
using ShopCaKoi.Repositores.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopCaKoi.WebApplication.Pages.Feedback
{
    public class FeedbackModel : PageModel
    {
        private readonly ICustomerService _customerService;

        public FeedbackModel(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // Danh sách phản hồi để hiển thị trên trang
        public List<ShopCaKoi.Repositores.Entities.Feedback> CustomerFeedbacks { get; set; } = new List<ShopCaKoi.Repositores.Entities.Feedback>();

        // Phản hồi mới từ form
        [BindProperty]
        public ShopCaKoi.Repositores.Entities.Feedback NewFeedback { get; set; }

        // Lấy danh sách phản hồi khi tải trang
        public async Task OnGetAsync()
        {
            CustomerFeedbacks = await _customerService.GetAllFeedbacksAsync();
        }

        // Xử lý gửi phản hồi mới (có thể hữu ích khi không dùng AJAX)
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                CustomerFeedbacks = await _customerService.GetAllFeedbacksAsync();
                return Page();
            }

            await _customerService.AddFeedbackAsync(NewFeedback);
            CustomerFeedbacks = await _customerService.GetAllFeedbacksAsync();

            // Xóa dữ liệu form sau khi gửi
            ModelState.Clear();
            return Page();
        }
    }
}
