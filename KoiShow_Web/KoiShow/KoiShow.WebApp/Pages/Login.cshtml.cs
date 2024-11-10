using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Interfaces;  // Đảm bảo đã có repository để truy xuất dữ liệu từ MySQL
using KoiShow.Repositories.Entities;
using System.Threading.Tasks;

namespace KoiShow.WebApp.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IKoiShowAccountRepository _accountRepository;  // Lớp Repository để truy cập MySQL

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public LoginModel(IKoiShowAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public string LoggedInUser { get; set; }

        public void OnGet()
        {
            LoggedInUser = HttpContext.Session.GetString("LoggedInUser");
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Vui lòng nhập tên người dùng và mật khẩu.";
                return Page();
            }

            var account = await _accountRepository.GetByUsernameAsync(Username);

            if (account == null || account.Password != Password)
            {
                ErrorMessage = "Tên người dùng hoặc mật khẩu không chính xác.";
                return Page();
            }
            // Lưu tên người dùng vào session sau khi đăng nhập thành công
            HttpContext.Session.SetString("LoggedInUser", Username);            
            return RedirectToPage("/login");
        }

    }
}
