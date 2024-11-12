using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces; // Thêm namespace cho interface

namespace KoiShow.WebApp.Pages.Account
{
    public class CreateModel : PageModel
    {
        private readonly IKoiShowAccountRepository _accountRepository; // Thay đổi thành repository

        public CreateModel(IKoiShowAccountRepository accountRepository) // Tiêm phụ thuộc repository
        {
            _accountRepository = accountRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Koishowaccount Koishowaccount { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Sử dụng repository để thêm tài khoản
            bool result = await _accountRepository.AddKoishowaccountAsync(Koishowaccount); // Gọi phương thức bất đồng bộ

            if (result) // Kiểm tra kết quả
            {
                return RedirectToPage("./Index");
            }
            else
            {
                ModelState.AddModelError("", "Có lỗi xảy ra khi thêm tài khoản.");
                return Page();
            }
        }
    }
}
