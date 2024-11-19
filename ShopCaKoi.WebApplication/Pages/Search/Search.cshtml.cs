using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Search
{
    public class SearchModel : PageModel
    {
		private readonly ITripService _service;

		public IEnumerable<Trip> SearchResults { get; set; } = new List<Trip>();

		[BindProperty(SupportsGet = true)]
		public string? Input { get; set; }

		public SearchModel(ITripService service)
		{
			_service = service;
		}

		public async Task OnGetAsync()
		{
			if (string.IsNullOrEmpty(Input))
			{
				SearchResults = new List<Trip>();
				return;
			}

			// Kiểm tra loại dữ liệu được nhập
			if (double.TryParse(Input, out var price))
			{
				// Người dùng nhập giá
				SearchResults = await _service.SearchTripsAsync(null, price,null);
			}
			else if (DateTime.TryParseExact(Input, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
			{
				// Người dùng nhập ngày
				SearchResults = await _service.SearchTripsAsync(null,null,date);
			}
			else
			{
				// Người dùng nhập từ khóa
				SearchResults = await _service.SearchTripsAsync(Input, null, null) ;
			}
		}
	}
}
