using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.WebApplication.Pages.InforCus
{
    public class IndexModel : PageModel
    {
        private readonly ShopCaKoi.Repositores.Entities.DataShopCaKoiContext _context;

        public IndexModel(ShopCaKoi.Repositores.Entities.DataShopCaKoiContext context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers.ToListAsync();
        }
    }
}
