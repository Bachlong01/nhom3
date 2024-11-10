using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCompetition
{
    public class CreateModel : PageModel
    {
        private readonly ICompetitionService _competitionService;

        public CreateModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Competition Competition { get; set; } = default!;

        // Phương thức OnPostAsync
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Sử dụng service để thêm cuộc thi
            bool result = _competitionService.AddCompetition(Competition); // Không cần await

            if (result) // Kiểm tra xem việc thêm có thành công không
            {
                return RedirectToPage("./Index");
            }

            // Nếu không thành công, bạn có thể thêm thông báo lỗi hoặc xử lý khác
            ModelState.AddModelError(string.Empty, "Không thể thêm cuộc thi. Vui lòng thử lại.");
            return Page();
        }
    }
}
