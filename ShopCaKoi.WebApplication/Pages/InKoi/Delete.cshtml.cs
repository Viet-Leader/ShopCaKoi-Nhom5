using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InKoi
{
	public class DeleteModel : PageModel
	{
		private readonly IKoiService _koiService;

		public DeleteModel(IKoiService koiService)
		{
			_koiService = koiService;
		}

		[BindProperty]
		public Koi Koi { get; set; } = default!;

		public async Task<IActionResult> OnGetAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var koi = await _koiService.GetKoiById(id);

			if (koi == null)
			{
				return NotFound();
			}
			else
			{
				Koi = koi;
			}
			return Page();
		}

		public async Task<IActionResult> OnPostAsync(string id)
		{
			if (id == null)
			{
				return NotFound();
			}

			_koiService.DelKoi(id);

			return RedirectToPage("./Index");
		}
	}
}
