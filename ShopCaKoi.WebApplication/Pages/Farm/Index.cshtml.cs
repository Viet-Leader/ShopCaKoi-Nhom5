using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Farm
{
	public class IndexModel : PageModel
	{
		private readonly IKoiFarmService _service;

		public IndexModel(IKoiFarmService service)
		{
			_service = service;
		}

		public IList<KoiFarm> KoiFarm { get; set; } = default!;
		public async Task OngetAsync()
		{
			KoiFarm = await _service.GetKoiFarmsAsync();
		}
	}
}
