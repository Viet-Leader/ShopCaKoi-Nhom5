using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly IShopCaKoiAccountService _service;

        public CreateModel(IShopCaKoiAccountService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ShopCaKoiAccount ShopCaKoiAccount { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var success = _service.AddShopCaKoiAccount(ShopCaKoiAccount);

            if (!success)
            {
                
                ModelState.AddModelError(string.Empty, "An error occurred while adding the account.");
                return Page();
            }


            return RedirectToPage("./Index");
        }
    }
}
