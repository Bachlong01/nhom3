using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShow.WebApp.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostLogoutAsync()
        {
           HttpContext.Session.Remove("LoggedInUser");

            // Thực hiện hành động đăng xuất như chuyển hướng
            return RedirectToPage("/Login");
        }

    }
}
