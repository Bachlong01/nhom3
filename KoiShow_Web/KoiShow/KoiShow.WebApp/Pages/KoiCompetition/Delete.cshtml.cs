using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCompetition
{
    public class DeleteModel : PageModel
    {
        private readonly ICompetitionService _competitionService;

        public DeleteModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [BindProperty]
        public Competition Competition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var competition = await _competitionService.GetCompetitionById(id.Value); // Sử dụng service để lấy cuộc thi

            if (competition == null)
            {
                return NotFound();
            }
            else
            {
                Competition = competition;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = _competitionService.DeleteCompetition(id.Value); // Sử dụng service để xóa cuộc thi

            if (result)
            {
                return RedirectToPage("./Index");
            }

            // Nếu không thành công, có thể thêm thông báo lỗi hoặc xử lý khác
            ModelState.AddModelError(string.Empty, "Không thể xóa cuộc thi. Vui lòng thử lại.");
            return Page();
        }
    }
}
