using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;

namespace KoiShow.WebApp.Pages.Account
{
    public class EditModel : PageModel
    {
        private readonly IKoiShowAccountService _service; // Sử dụng service

        public EditModel(IKoiShowAccountService service)
        {
            _service = service; // Tiêm phụ thuộc
        }

        [BindProperty]
        public Koishowaccount Koishowaccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koishowaccount = await _service.GetKoishowaccountByIdAsync((int)id);
            if (koishowaccount == null)
            {
                return NotFound();
            }

            Koishowaccount = koishowaccount;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Sử dụng service để cập nhật tài khoản
            var updateResult = await _service.DelKoishowaccountAsync(Koishowaccount); // Gọi phương thức đồng bộ

            if (!updateResult)
            {
                ModelState.AddModelError(string.Empty, "Không thể cập nhật tài khoản.");
                return Page();
            }

            return RedirectToPage("./Index");
        }
    }
}
