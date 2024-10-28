using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforTrip
{
    public class CreateModel : PageModel
    {
        private readonly ITripService _service;
        private readonly ShopCaKoi.Repositores.Entities.DataShopCaKoiContext _context;

        public CreateModel(ITripService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
        ViewData["FarmId"] = new SelectList(_context.KoiFarms, "FarmId", "FarmId");
        ViewData["KoiId"] = new SelectList(_context.Kois, "KoiId", "KoiId");
            return Page();
        }

        [BindProperty]
        public Trip Trip { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            object value1 = _context.Trips.Add(Trip);
            object value = await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
