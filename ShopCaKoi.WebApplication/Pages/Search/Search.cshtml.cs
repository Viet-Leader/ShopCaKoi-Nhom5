using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Search
{
	public class SearchModel : PageModel
	{

		private readonly ITripService _service;
		public IEnumerable<Trip> SearchResults { get; set; }

		public SearchModel(ITripService service)
		{
			_service = service;
		}

		public async Task OnGetAsync(string query)
		{
			if (!string.IsNullOrEmpty(query))
			{
				SearchResults = await _service.SearchTripsAsync(query);
			}
			else
			{
				SearchResults = new List<Trip>();
			}
		}
	}

}
