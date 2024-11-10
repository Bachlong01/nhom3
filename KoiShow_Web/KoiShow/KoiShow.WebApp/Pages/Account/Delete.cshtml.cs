using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;

namespace KoiShow.WebApp.Pages.Account
{
    public class DeleteModel : PageModel
    {
        private readonly IKoiShowAccountService _service;

        public DeleteModel(IKoiShowAccountService service)
        {
            _service = service;
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
            else
            {
                Koishowaccount = koishowaccount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Gọi phương thức bất đồng bộ
            bool result = await _service.DelKoishowaccountAsync((int)id);

            if (!result)
            {
                return NotFound(); // Nếu xóa không thành công
            }

            return RedirectToPage("./Index");
        }
    }
}
