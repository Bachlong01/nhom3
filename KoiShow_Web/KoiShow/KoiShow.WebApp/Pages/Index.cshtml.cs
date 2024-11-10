using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShow.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
      
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
        public string LoggedInUser { get; set; }
        public void OnGet()
        {
            LoggedInUser = HttpContext.Session.GetString("LoggedInUser");
        }
    }
}
