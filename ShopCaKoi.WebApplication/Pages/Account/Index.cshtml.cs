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
    public class IndexModel : PageModel
    {
        private readonly IShopCaKoiAccountService _service;

        public IndexModel(IShopCaKoiAccountService service)
        {
            _service = service;
        }

        public IList<ShopCaKoiAccount> ShopCaKoiAccount { get; set; } = default!;

        public async Task OnGetAsync()
        {
            ShopCaKoiAccount = await _service.ShopCaKoiAccounts();
        }
    }
}
