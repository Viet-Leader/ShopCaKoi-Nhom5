using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;
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

        // Danh s�ch ph?n h?i
        public List<ShopCaKoi.Repositores.Entities.Feedback> Feedbacks { get; set; } = new List<ShopCaKoi.Repositores.Entities.Feedback>();

        // Ph?n h?i m?i t? form
        [BindProperty]
        public ShopCaKoi.Repositores.Entities.Feedback NewFeedback { get; set; }

        // T?i danh s�ch ph?n h?i khi truy c?p trang
        public async Task OnGetAsync()
        {
            Feedbacks = await _customerService.GetAllFeedbacksAsync();
        }

        // X? l� g?i ph?n h?i m?i
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                Feedbacks = await _customerService.GetAllFeedbacksAsync();
                return Page();
            }

            // Th�m ph?n h?i m?i
            await _customerService.AddFeedbackAsync(NewFeedback);

            // L?y l?i danh s�ch ph?n h?i sau khi th�m
            Feedbacks = await _customerService.GetAllFeedbacksAsync();

            // X�a d? li?u form sau khi g?i
            ModelState.Clear();
            return Page();
        }
    }
}
