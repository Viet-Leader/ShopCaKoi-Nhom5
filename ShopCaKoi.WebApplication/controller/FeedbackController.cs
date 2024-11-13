using Microsoft.AspNetCore.Mvc;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopCaKoi.WebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public FeedbackController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        // Phương thức POST để thêm phản hồi
        [HttpPost]
        public async Task<IActionResult> PostFeedback([FromBody] Feedback feedback)
        {
            if (feedback == null)
            {
                return BadRequest("Phản hồi không hợp lệ.");
            }

            var result = await _customerService.AddFeedbackAsync(feedback);
            if (result)
            {
                return Ok();
            }

            return StatusCode(500, "Không thể thêm phản hồi.");
        }

        // Phương thức GET để lấy tất cả các phản hồi
        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> GetFeedbacks()
        {
            var feedbacks = await _customerService.GetAllFeedbacksAsync();
            return Ok(feedbacks);
        }
    }
}