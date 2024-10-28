using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforTrip
{
    public class SearchModel : PageModel
    {
        private readonly ITripService _service;
        public SearchModel(ITripService service)
        {
            _service = service;
        }

        [BindProperty(SupportsGet = true)]
        public string? FarmName { get; set; }
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

        public IEnumerable<Trip> Trips { get; set; }

        public async Task OnGetAsync()
        {
            Trips = _service.SearchTripsAdvanced(FarmName, KoiSpecies, StartDate, EndDate, MinPrice, MaxPrice);
        }
    }
}
