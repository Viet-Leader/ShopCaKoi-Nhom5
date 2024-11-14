using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopCaKoi.Repositores;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.Farm
{
    

    public class DetailsModel : PageModel
    {

        private readonly IKoiFarmService _service;
        private readonly IKoiService _koiService;

        public KoiFarm KoiFarm { get; set; } = null!; // Trại cá
        public IEnumerable<Koi> Kois { get; set; } = new List<Koi>(); // Danh sách các loại cá Koi

        public DetailsModel(IKoiFarmService service,IKoiService koiService)
        {
            _koiService = koiService;
            _service = service;
        }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            // Lấy thông tin trại cá theo farmId
            KoiFarm = await _service.GetKoiFarmById(id);
            if (KoiFarm == null)
            {
                return NotFound();
            }

            // Lấy danh sách các loại cá Koi liên kết với farmId
            Kois = await _koiService.GetKoiByFarmIdAsync(id);
            return Page();
        }
    }
}
