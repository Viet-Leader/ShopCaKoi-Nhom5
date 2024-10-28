using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforTrip
{
    public class EditModel : PageModel
    {
        private readonly ITripService _service;
        private readonly IKoiFarmService _koiFarmService;
        private readonly IKoiService _koiService;

        public EditModel(ITripService service, IKoiFarmService koiFarmService, IKoiService koiService)
        {
            _service = service;
            _koiFarmService = koiFarmService;
            _koiService = koiService;
        }

        [BindProperty]
        public Trip Trip { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Trip = await _service.GetTripById(id);
            if (Trip == null)
            {
                return NotFound();
            }
            var koiFarms = await _koiFarmService.GetKoiFarmsAsync();
            var kois = await _koiService.GetKoisAsync();

            ViewData["FarmId"] = new SelectList(koiFarms, "FarmId", "FarmId");
            ViewData["KoiId"] = new SelectList(kois, "KoiId", "KoiId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Kiểm tra xem tài khoản có tồn tại thông qua service
                if (!_service.TripExists(Trip.TripId))
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại. Không thể cập nhật.");
                    return Page(); // Trả về trang hiện tại với thông báo lỗi
                }

                bool isUpdated = _service.UpdTrip(Trip);
                if (!isUpdated)
                {
                    ModelState.AddModelError(string.Empty, "Cập nhật không thành công. Vui lòng thử lại.");
                    return Page();
                }
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu cần
                ModelState.AddModelError(string.Empty, "Có lỗi xảy ra: " + ex.Message);
                return Page();
            }

            return RedirectToPage("./Index");
        }
    
    }
}
