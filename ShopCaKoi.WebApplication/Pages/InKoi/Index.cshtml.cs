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
	public class IndexModel : PageModel
	{
		private readonly IKoiService _koiService;

		public IndexModel(IKoiService koiService)
		{
			_koiService = koiService;
		}
		[BindProperty(SupportsGet = true)]
		public string? KoiName { get; set; }
		[BindProperty(SupportsGet = true)]
		public string? KoiSpecies { get; set; }
		[BindProperty(SupportsGet = true)]
		public DateTime? StartDate { get; set; }
		[BindProperty(SupportsGet = true)]
		public DateTime? EndDate { get; set; }
		[BindProperty(SupportsGet = true)]
		public double? MinPrice { get; set; }
		[BindProperty(SupportsGet = true)]
		public double? MaxPrice { get; set; }
		public string? ImageUrl { get; set; }

		public IList<Koi> Koi { get; set; } = default!;

		public async Task OnGetAsync()
		{
			Koi = await _koiService.GetKoisAsync();
		}
	}
}
