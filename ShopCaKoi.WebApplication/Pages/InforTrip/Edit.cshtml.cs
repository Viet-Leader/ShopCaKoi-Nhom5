using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.WebApplication.Pages.InforTrip
{
    public class EditModel : PageModel
    {
        private readonly ShopCaKoi.Repositores.Entities.DataShopCaKoiContext _context;

        public EditModel(ShopCaKoi.Repositores.Entities.DataShopCaKoiContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Trip Trip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip =  await _context.Trips.FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }
            Trip = trip;
           ViewData["FarmId"] = new SelectList(_context.KoiFarms, "FarmId", "FarmId");
           ViewData["KoiId"] = new SelectList(_context.Kois, "KoiId", "KoiId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Trip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(Trip.TripId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TripExists(string id)
        {
            return _context.Trips.Any(e => e.TripId == id);
        }
    }
}
