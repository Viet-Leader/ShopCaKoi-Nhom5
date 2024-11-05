using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Search
{
    public class IndexModel : PageModel
    {
        private readonly ITripService _service;

        public IndexModel(ITripService service)
        {
            _service = service;
        }


        public IList<Trip> Trip { get; set; } = default!;

        public async Task OnGetAsync(string? keyword)
        {
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                Trip = await _service.SearchTripsAsync(keyword);

                if (Trip == null || !Trip.Any())
                {
                    // Nếu không có kết quả, tạo một danh sách rỗng để thông báo trong giao diện
                    Trip = new List<Trip>();
                    ViewData["NoResultsMessage"] = "Không có kết quả cần tìm";
                }
            }
            else
            {
                Trip = new List<Trip>(); // Nếu không có từ khóa, trả về danh sách trống
                ViewData["NoResultsMessage"] = "Không có kết quả cần tìm";
            }
        }

    }
}
