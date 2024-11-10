using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InKoi
{
	public class EditModel : PageModel
	{
		private readonly IKoiService _koiService;
		private readonly IQuotationService _quotationService;
		private readonly ICustomerService _customerService;
		public EditModel(ICustomerService customerService, IQuotationService quotationService, IKoiService koiService)
		{
			_koiService = koiService;
			_customerService = customerService;
			_quotationService = quotationService;
		}

		[BindProperty]
		public Koi Koi { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			Koi = await _koiService.GetKoiById(id);
			if (Koi == null)
			{
				return NotFound();
			}
			var customer = await _customerService.GetCustomerWithDetailAsync();
			var quotation = await _quotationService.GetAllQuotations();

			ViewData["customerId"] = new SelectList(customer, "customerId", "customerId");
			ViewData["quotations"] = new SelectList(quotation, "quotations", "quotations");
			return Page();
		}

		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more information, see https://aka.ms/RazorPagesCRUD.
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}

			try
			{
				// Kiểm tra xem tài khoản có tồn tại thông qua service
				if (!_koiService.KoiExists(Koi.KoiId))
				{
					ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại. Không thể cập nhật.");
					return Page(); // Trả về trang hiện tại với thông báo lỗi
				}

				bool isUpdated = _koiService.UpdKoi(Koi);
				if (!isUpdated)
				{
					ModelState.AddModelError(string.Empty, "Cập nhật không thành công. Vui lòng thử lại.");
					return Page();
				}
			}
			catch (Exception ex)
			{
				// Xử lý lỗi nếu cần
				ModelState.AddModelError(string.Empty, "Có lỗi xảy ra: " + ex.Message);
				return Page();
			}

			return RedirectToPage("./Index");
		}
	}
}
