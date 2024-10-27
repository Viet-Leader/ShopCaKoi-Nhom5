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

namespace ShopCaKoi.WebApplication.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly IShopCaKoiAccountService _service;

        public EditModel(IShopCaKoiAccountService service)
        {
            _service = service;
        }


        [BindProperty]
        public ShopCaKoiAccount ShopCaKoiAccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShopCaKoiAccount = await _service.GetShopCaKoiAccountById(id);
            if (ShopCaKoiAccount == null)
            {
                return NotFound();
            }

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
                if (!_service.ShopCaKoiAccountExists(ShopCaKoiAccount.AccId))
                {
                    ModelState.AddModelError(string.Empty, "Tài khoản không tồn tại. Không thể cập nhật.");
                    return Page(); // Trả về trang hiện tại với thông báo lỗi
                }

                bool isUpdated = _service.UpdShopCaKoiAccount(ShopCaKoiAccount);
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
