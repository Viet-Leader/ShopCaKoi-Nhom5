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
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool isAdded = _service.AddShopCaKoiAccount(ShopCaKoiAccount);
            if (!isAdded)
            {
                ModelState.AddModelError(string.Empty, "Lỗi khi thêm tài khoản. Vui lòng thử lại.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
