using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces; // Thêm namespace cho interface

namespace KoiShow.WebApp.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IKoiShowAccountRepository _accountRepository; // Thay đổi thành repository
        public string LoggedInUser { get; set; }
        public IEnumerable<Competition> Competitions { get; set; }

        public RegisterModel(IKoiShowAccountRepository accountRepository) // Tiêm phụ thuộc repository
        {
            _accountRepository = accountRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            // Lấy tên người dùng đã đăng nhập từ session
            LoggedInUser = HttpContext.Session.GetString("LoggedInUser");

            // Trả về trang với dữ liệu đã xử lý
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
                TempData["SuccessMessage"] = "Success Register!";
                return RedirectToPage("./Login");
            }
            else
            {
                TempData["ErrorMessage"] = "Id or username is already in use.";
                return RedirectToPage();
            }
        }
    }
}
