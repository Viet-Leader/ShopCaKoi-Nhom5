using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InKoi
{
	public class CreateModel : PageModel
	{
		private readonly IKoiService _koiService;
		private readonly IQuotationService _quotationService;
		private readonly ICustomerService _customerService;
		public CreateModel(ICustomerService customerService, IQuotationService quotationService, IKoiService koiService)
		{
			_koiService = koiService;
			_customerService = customerService;
			_quotationService = quotationService;
		}


		[BindProperty]
		public Koi Koi { get; set; } = default!;

		// For more information, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnGetAsync()
		{
			var customer = await _customerService.GetCustomerWithDetailAsync();
			var quotation = await _quotationService.GetAllQuotations();

			ViewData["customerId"] = new SelectList(customer, "customerId", "customerId");
			ViewData["quotations"] = new SelectList(quotation, "quotations", "quotations");

			return Page();
		}
		public async Task<IActionResult> OnPost()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			bool isAdded = _koiService.AddKoi(Koi);
			if (!isAdded)
			{
				ModelState.AddModelError(string.Empty, "Lỗi . Vui lòng thử lại.");
				return Page();
			}

			return RedirectToPage("./Index");
		}
	}
}
