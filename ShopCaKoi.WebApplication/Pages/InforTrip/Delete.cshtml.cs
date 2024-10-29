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
    public class DeleteModel : PageModel
    {
        private readonly ITripService _service;

        public DeleteModel(ITripService service)
        {
            _service = service;
        }

        [BindProperty]
        public Trip Trip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _service.GetTripById(id);

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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _service.DelTrip(id);

            return RedirectToPage("./Index");
        }
    }
}
