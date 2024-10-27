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
    public class DetailsModel : PageModel
    {
        private readonly IShopCaKoiAccountService _service;

        public DetailsModel(IShopCaKoiAccountService service)
        {
            _service = service;
        }

        public ShopCaKoiAccount ShopCaKoiAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Sử dụng dịch vụ để lấy tài khoản
            ShopCaKoiAccount = await _service.GetShopCaKoiAccountById(id);
            if (ShopCaKoiAccount == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
