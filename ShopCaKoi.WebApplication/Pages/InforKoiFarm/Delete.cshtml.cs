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
    public class DeleteModel : PageModel
    {
		private readonly IKoiFarmService _service;

		public DeleteModel(IKoiFarmService service)
		{
			_service = service;
		}

		[BindProperty]
		public KoiFarm KoiFarm { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var koifarm = await _service.GetKoiFarmById(id);

			if (koifarm == null)
			{
				return NotFound();
			}
			else
			{
				KoiFarm = koifarm;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			_service.DelKoiFarm(id);

			return RedirectToPage("./Index");
		}
	}
}
