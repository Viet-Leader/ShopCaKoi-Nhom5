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

        [BindProperty(SupportsGet = true)]
        public string Query { get; set; } // Từ khóa tìm kiếm

        [BindProperty(SupportsGet = true)]
        public double? Price { get; set; } // Giá tìm kiếm

        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; } // Ngày bắt đầu tìm kiếm

        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; } // Ngày kết thúc tìm kiếm

        public SearchModel(ITripService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            if (!string.IsNullOrEmpty(Query) || Price.HasValue || StartDate.HasValue || EndDate.HasValue)
            {
                SearchResults = await _service.SearchTripsAsync(Query, Price, StartDate, EndDate);
            }
            else
            {
                SearchResults = new List<Trip>();
            }
        }
    }
}
