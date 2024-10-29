using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforTrip
{
    public class IndexModel : PageModel
    {
        private readonly ITripService _service;

        public IndexModel(ITripService service)
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

        public IList<Trip> Trip { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Chỉ thực hiện tìm kiếm nếu có ít nhất một tiêu chí được cung cấp
            if (!string.IsNullOrWhiteSpace(FarmName) || !string.IsNullOrWhiteSpace(KoiSpecies) ||
                StartDate.HasValue || EndDate.HasValue || MinPrice.HasValue || MaxPrice.HasValue)
            {
                Trip = await _service.SearchTripsAdvanced(FarmName, KoiSpecies, StartDate, EndDate, MinPrice, MaxPrice);
            }
            else
            {
                Trip = await _service.GetTripsWithDetailsAsync(); // Lấy tất cả các chuyến đi nếu không có tiêu chí tìm kiếm
            }
        }
    }
}
