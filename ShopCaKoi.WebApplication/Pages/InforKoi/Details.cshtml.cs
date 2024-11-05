using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforKoi
{
    public class DetailsModel : PageModel
    {
		private readonly IKoiService _service;

		public DetailsModel(IKoiService service)
		{
			_service = service;
		}

		public Koi Koi { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			// Sử dụng dịch vụ để lấy tài khoản
			Koi = await _service.GetKoiById(id);
			if (Koi == null)
			{
				return NotFound();
			}

			return Page();
		}
	}
}
