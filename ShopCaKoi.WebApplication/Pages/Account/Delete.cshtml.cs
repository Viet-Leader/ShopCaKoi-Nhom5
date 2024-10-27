using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly IShopCaKoiAccountService _service;

        public DeleteModel(IShopCaKoiAccountService service)
        {
            _service = service;
        }

        [BindProperty]
        public ShopCaKoiAccount ShopCaKoiAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            
            if (id == null)
            {
                return NotFound();
            }
            

            var shopcakoiaccount = await _service.GetShopCaKoiAccountById(id);

            if (shopcakoiaccount == null)
            {
                return NotFound();
            }
            else
            {
                ShopCaKoiAccount = shopcakoiaccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            _service.DelShopCaKoiAccount(id);
            return RedirectToPage("./Index");
        }
    }
}
