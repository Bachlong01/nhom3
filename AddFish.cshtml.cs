using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace KoiShow.WebApp.Pages
{
    public class AddFishModel : PageModel
    {

        public string ErrorMessage { get; set; }

        public string LoggedInUser { get; set; }

        public void OnGet()
        {
            // Lấy thông tin người dùng từ session
            LoggedInUser = HttpContext.Session.GetString("LoggedInUser");

            if (string.IsNullOrEmpty(LoggedInUser))
            {
                ErrorMessage = "Vui lòng đăng nhập để thêm cá.";
            }
        }
    }
}
