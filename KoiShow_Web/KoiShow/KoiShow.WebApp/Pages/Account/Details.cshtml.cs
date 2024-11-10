using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;

namespace KoiShow.WebApp.Pages.Account
{
    public class DetailsModel : PageModel
    {
        private readonly IKoiShowAccountService _accountService; // Sử dụng interface

        public DetailsModel(IKoiShowAccountService accountService) // Tiêm phụ thuộc service
        {
            _accountService = accountService;
        }

        public Koishowaccount Koishowaccount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Sử dụng AccountService để lấy tài khoản
            var koishowaccount = await _accountService.GetKoishowaccountByIdAsync((int)id);
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
    }
}
