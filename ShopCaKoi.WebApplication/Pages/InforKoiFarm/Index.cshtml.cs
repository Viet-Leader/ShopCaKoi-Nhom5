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
    public class IndexModel : PageModel
    {
		private readonly IKoiFarmService _service;

		public IndexModel(IKoiFarmService service)
		{
			_service = service;
		}

		public IList<KoiFarm> KoiFarm { get; set; } = default!;

		public async Task OnGetAsync()
		{
			KoiFarm = await _service.GetKoiFarmsAsync();
		}
	}
}
