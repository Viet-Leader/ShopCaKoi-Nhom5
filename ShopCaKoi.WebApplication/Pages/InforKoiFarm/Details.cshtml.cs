using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforKoiFarm
{
    public class DetailsModel : PageModel
    {
		private readonly IKoiFarmService _service;

		public DetailsModel(IKoiFarmService service)
		{
			_service = service;
		}

		public KoiFarm KoiFarm { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			// Sử dụng dịch vụ để lấy tài khoản
			KoiFarm = await _service.GetKoiFarmById(id);
			if (KoiFarm == null)
			{
				return NotFound();
			}

			return Page();
		}
	}
    
}
