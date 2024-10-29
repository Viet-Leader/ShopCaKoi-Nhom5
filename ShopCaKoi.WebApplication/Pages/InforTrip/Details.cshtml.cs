using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforTrip
{
    public class DetailsModel : PageModel
    {
        private readonly ITripService _service;

        public DetailsModel(ITripService service)
        {
            _service = service;
        }

        public Trip Trip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Sử dụng dịch vụ để lấy tài khoản
            Trip = await _service.GetTripById(id);
            if (Trip == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
