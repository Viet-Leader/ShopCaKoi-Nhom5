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
		public string ReturnUrl { get; set; } = "/";

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

		private void UpdateCartState(string customerId)
		{
			Cart = _service.GetCartDetails(customerId) ?? new Cart
			{
				CartItems = new List<CartItem>()
			};
			TotalPrice = Cart.CartItems.Any()
				? Cart.CartItems.Sum(item => item.Price * item.Quantity)
				: 0;

			_logger.LogInformation("Cart updated for customer {CustomerId}. Total items: {ItemCount}, Total price: {TotalPrice}.",
				customerId, Cart.CartItems.Count, TotalPrice);
		}

		public IActionResult OnGet()
		{
			try
			{
				var customerId = GetCustomerId();
				UpdateCartState(customerId);

				if (!Cart.CartItems.Any())
				{
					_logger.LogInformation("Cart is empty for customer {CustomerId}. Redirecting to EmptyCart page.", customerId);
					return RedirectToPage("/InCart/EmptyCart");
				}

				return Page();
			}
			catch (UnauthorizedAccessException)
			{
				return RedirectToPage("/Profiles/LogIn", new { ReturnUrl = Url.Page("/InCart/InCart") });
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
				UpdateCartState(customerId);

				return RedirectToPage("/InCart/InCart");
			}
			catch (UnauthorizedAccessException)
			{
				return RedirectToPage("/Profiles/LogIn", new { ReturnUrl = Url.Page("/InCart/InCart") });
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

				UpdateCartState(customerId);

				if (!Cart.CartItems.Any())
				{
					_logger.LogInformation("Cart is empty for customer {CustomerId}. Redirecting to EmptyCart page.", customerId);
					return RedirectToPage("/InCart/EmptyCart");
				}

				return Page();
			}
			catch (UnauthorizedAccessException)
			{
				return RedirectToPage("/Profiles/LogIn", new { ReturnUrl = Url.Page("/InCart/InCart") });
			}
		}

        public IActionResult OnPostRemoveItem(string cartItemId)
        {
            try
            {
                var customerId = GetCustomerId();

                if (string.IsNullOrEmpty(cartItemId))
                {
                    _logger.LogWarning("Attempt to remove an item with an invalid ID.");
                    ModelState.AddModelError(string.Empty, "The item does not exist.");
                    UpdateCartState(customerId);
                    return Page(); // Trả về trang hiện tại
                }

                _service.RemoveItemFromCart(cartItemId);
                UpdateCartState(customerId);

                return Page(); // Trả về lại Razor Page với dữ liệu mới
            }
            catch (UnauthorizedAccessException)
            {
                return RedirectToPage("/Profiles/LogIn", new { ReturnUrl = Url.Page("/InCart/InCart") });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while removing item {CartItemId}.", cartItemId);
                return StatusCode(500, "Internal server error. Please try again later.");
            }
        }
    }
	
}
