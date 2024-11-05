using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.WebApplication.Pages.InforKoi
{
    public class CreateModel : PageModel
    {
        private readonly IKoiService _service;

        public CreateModel(IKoiService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Koi Koi { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
			if (!ModelState.IsValid)
			{
				return Page();
			}

			bool isAdded = _service.AddKoi(Koi);
			if (!isAdded)
			{
				ModelState.AddModelError(string.Empty, "Lỗi khi thêm . Vui lòng thử lại.");
				return Page();
			}

			return RedirectToPage("./Index");
		}
    }
}
