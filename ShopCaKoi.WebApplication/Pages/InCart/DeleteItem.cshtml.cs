using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Sevices.Interfaces;
using Microsoft.Extensions.Logging;

namespace ShopCaKoi.WebApplication.Pages.InCart
{
    public class DeleteItemModel : PageModel
    {
        private readonly ICartService _service;
        private readonly ILogger<DeleteItemModel> _logger;

        public string ItemId { get; set; }
        public string ReturnUrl { get; set; }

        public DeleteItemModel(ICartService service, ILogger<DeleteItemModel> logger)
        {
            _service = service;
            _logger = logger;
        }

        // This method handles the GET request and prepares the page with the item to delete.
        public IActionResult OnGet(string itemId, string returnUrl)
        {
            if (string.IsNullOrEmpty(itemId))
            {
                _logger.LogError("Item ID is required.");
                return RedirectToPage("/InCart/InCart");
            }

            ItemId = itemId;
            ReturnUrl = returnUrl ?? "/InCart/InCart"; // Default return URL is the cart page

            return Page();
        }

        // This method handles the POST request to delete the item from the cart.
        public IActionResult OnPost()
        {
            if (string.IsNullOrEmpty(ItemId))
            {
                ModelState.AddModelError(string.Empty, "Item ID is required to delete the item.");
                return Page();
            }

            try
            {
                _service.RemoveItemFromCart(ItemId);
                _logger.LogInformation($"Item {ItemId} removed from the cart.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while trying to remove the item from the cart.");
                ModelState.AddModelError(string.Empty, "An error occurred while trying to remove the item.");
                return Page();
            }

            return RedirectToPage("/InCart/InCart");
        }
    }
}
