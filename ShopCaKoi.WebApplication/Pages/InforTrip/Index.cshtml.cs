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
    public class IndexModel : PageModel
    {
        private readonly ShopCaKoi.Repositores.Entities.DataShopCaKoiContext _context;

        public IndexModel(ShopCaKoi.Repositores.Entities.DataShopCaKoiContext context)
        {
            _context = context;
        }

        public IList<Trip> Trip { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Trip = await _context.Trips
                .Include(t => t.Farm)
                .Include(t => t.Koi).ToListAsync();
        }
    }
}
