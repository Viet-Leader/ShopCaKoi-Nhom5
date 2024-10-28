using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforTrip
{
    public class CreateModel : PageModel
    {
        private readonly ITripService _service;
        private readonly IKoiFarmService _koiFarmService;
        private readonly IKoiService _koiService;

        public CreateModel(ITripService service,IKoiFarmService koiFarmService,IKoiService koiService)
        {
            _service = service;
            _koiFarmService = koiFarmService;
            _koiService = koiService;
        }
       
        public async Task<IActionResult> OnGetAsync()
        {
            var koiFarms = await _koiFarmService.GetKoiFarmsAsync();
            var kois = await _koiService.GetKoisAsync();

            ViewData["FarmId"] = new SelectList(koiFarms, "FarmId", "FarmId");
            ViewData["KoiId"] = new SelectList(kois, "KoiId", "KoiId");

            return Page();
        }

        [BindProperty]
        public Trip Trip { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool isAdded = _service.AddTrip(Trip);
            if (!isAdded)
            {
                ModelState.AddModelError(string.Empty, "Lỗi khi thêm tài khoản. Vui lòng thử lại.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
