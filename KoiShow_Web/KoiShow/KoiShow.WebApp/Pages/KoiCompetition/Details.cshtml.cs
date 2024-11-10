using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCompetition
{
    public class DetailsModel : PageModel
    {
        private readonly ICompetitionService _competitionService;

        public DetailsModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        public Competition Competition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Competition = await _competitionService.GetCompetitionById(id.Value); // Sử dụng service để lấy thông tin cuộc thi

            if (Competition == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
