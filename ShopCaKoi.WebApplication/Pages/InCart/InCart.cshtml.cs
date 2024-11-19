using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ShopCaKoi.WebApplication.Pages.InCart
{
    public class InCartModel : PageModel
    {
        private readonly ICartService _service;
        private readonly ILogger<InCartModel> _logger;

        public InCartModel(ICartService service, ILogger<InCartModel> logger)
        {
            _service = service;
            _logger = logger;
        }

        public Cart Cart { get; set; } = new Cart
        {
            CartItems = new List<CartItem>()
        };

        public decimal TotalPrice { get; set; }

        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        private string GetCustomerId()
        {
            var customerId = HttpContext.Session.GetString("CustomerId");
            if (string.IsNullOrEmpty(customerId))
            {
                _logger.LogWarning("User is not logged in. Redirecting to login page.");
                throw new UnauthorizedAccessException("User is not logged in.");
            }
            return customerId;
        }

        public IActionResult OnGet()
        {
            try
            {
                var customerId = GetCustomerId();
                Cart = _service.GetCartDetails(customerId) ?? new Cart
                {
                    CartItems = new List<CartItem>()
                };

                if (!Cart.CartItems.Any())
                {
                    ModelState.AddModelError(string.Empty, "Your cart is empty.");
                    TotalPrice = 0;
                    return Page();
                }

                TotalPrice = Cart.CartItems.Sum(item => (item.Price ) * (item.Quantity ));

                return Page();
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToPage("/Profiles/LogIn", new { ReturnUrl = "/InCart/InCart" });
            }
        }

        public IActionResult OnPostAddToCart(string? koiId, string? tripId, decimal price, int quantity)
        {
            try
            {
                var customerId = GetCustomerId();

                if (quantity <= 0)
                {
                    ModelState.AddModelError(string.Empty, "Quantity must be greater than 0.");
                    return Page();
                }

                if (string.IsNullOrEmpty(koiId) && string.IsNullOrEmpty(tripId))
                {
                    ModelState.AddModelError(string.Empty, "You must select a product or trip.");
                    return Page();
                }

                _service.AddToCart(customerId, koiId, tripId, price, quantity);
                return RedirectToPage("/InCart/InCart");
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToPage("/Profiles/LogIn", new { ReturnUrl = "/InCart/InCart" });
            }
        }

        public IActionResult OnPostUpdateItem(string id, int quantity)
        {
            try
            {
                var customerId = GetCustomerId();

                if (quantity <= 0)
                {
                    _service.RemoveItemFromCart(id);
                }
                else
                {
                    _service.UpdateCartItem(customerId, id, quantity);
                }

                return RedirectToPage("/InCart/InCart");
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToPage("/Profiles/LogIn", new { ReturnUrl = "/InCart/InCart" });
            }
        }

        public IActionResult OnPostRemoveItem(string cartItemId, string customerId)
        {
            // Kiểm tra nếu customerId không hợp lệ
            if (string.IsNullOrEmpty(customerId))
            {
                ReturnUrl = "/InCart";
                return RedirectToPage("/Profiles/LogIn", new { ReturnUrl });
            }

            // Kiểm tra nếu cartItemId không hợp lệ
            if (string.IsNullOrEmpty(cartItemId))
            {
                ModelState.AddModelError(string.Empty, "Product does not exist.");
                return RedirectToPage("/InCart/InCart", new { customerId });
            }

            // Gọi dịch vụ để xóa sản phẩm khỏi giỏ hàng
            _service.RemoveItemFromCart(cartItemId);

            // Chuyển hướng lại trang giỏ hàng sau khi xóa
            return RedirectToPage("/InCart/InCart", new { customerId });
        }


    }
}
