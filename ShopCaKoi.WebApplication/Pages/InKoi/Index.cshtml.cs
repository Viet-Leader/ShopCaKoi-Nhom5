using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InKoi
{
	public class IndexModel : PageModel
	{
            private readonly IKoiService _service;
            private readonly ICartService _cartService;

            public IndexModel(IKoiService service, ICartService cartService)
            {
                _service = service;
                _cartService = cartService;
            }


            public IList<Koi> Koi { get; set; } = default!;

            public async Task OnGetAsync()
            {
                Koi = await _service.GetKoisAsync();
            }
            public IActionResult OnPostAddToCart(string koiID, decimal price, int quantity)
            {
                var customerId = HttpContext.Session.GetString("CustomerId");
                if (string.IsNullOrEmpty(customerId))
                {
                    return RedirectToPage("/Profiles/LogIn");
                }

                _cartService.AddToCart(customerId, koiID, null, price, quantity);
                return RedirectToPage("/InCart/InCart", new { customerId });
            }
        public IActionResult OnPostRemove(string cartItemId)
        {
            var customerId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerId))
            {
                return RedirectToPage("/Profiles/LogIn");
            }

            // Gọi dịch vụ xóa sản phẩm khỏi giỏ hàng
            _cartService.RemoveItemFromCart( cartItemId);

            // Quay lại trang InCart
            return RedirectToPage("/InCart/InCart", new { customerId });
        }

    }
}

