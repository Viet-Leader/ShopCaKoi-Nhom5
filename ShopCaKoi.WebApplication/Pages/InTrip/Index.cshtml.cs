using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InTrip
{
    public class IndexModel : PageModel
    {
        private readonly ITripService _service;

        public IndexModel(ITripService service)
        {
            _service = service;
        }


        public IList<Trip> Trip { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Trip = await _service.GetTripsWithDetailsAsync();
        }
    }
}