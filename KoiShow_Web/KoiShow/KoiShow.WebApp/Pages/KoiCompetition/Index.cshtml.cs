using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCompetition
{
    public class IndexModel : PageModel
    {
        private readonly ICompetitionService _competitionService;

        public IndexModel(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        public IList<Competition> Competitions { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Competitions = await _competitionService.GetCompetitions();
        }
    }
}
