using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.WebApplication.Pages.InforTrip
{
    public class DetailsModel : PageModel
    {
        private readonly ShopCaKoi.Repositores.Entities.DataShopCaKoiContext _context;

        public DetailsModel(ShopCaKoi.Repositores.Entities.DataShopCaKoiContext context)
        {
            _context = context;
        }

        public Trip Trip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips.FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }
            else
            {
                Trip = trip;
            }
            return Page();
        }
    }
}
