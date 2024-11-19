using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Services;
using ShopCaKoi.Sevices.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InTrip
{
    public class IndexModel : PageModel
    {
        private readonly ITripService _service;
        private readonly ICartService _cartService;

        public IndexModel(ITripService service, ICartService cartService)
        {
            _service = service;
            _cartService = cartService;
        }


        public IList<Trip> Trip { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Trip = await _service.GetTripsWithDetailsAsync();
        }
        public IActionResult OnPostAddToCart(string tripId, decimal price, int quantity)
        {
            var customerId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToPage("/Profiles/LogIn");
            }

            _cartService.AddToCart(customerId, null, tripId, price, quantity);
            return RedirectToPage("/InCart/InCart", new { customerId });
        }
    }
}
