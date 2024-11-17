using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShow.WebApp.Pages
{
    public class CandidateModel : PageModel
    {
        public string LoggedInUser { get; set; }

        public void OnGet()
        {
            // Lấy tên người dùng đã đăng nhập từ session
            LoggedInUser = HttpContext.Session.GetString("LoggedInUser");
        }
    }
}
