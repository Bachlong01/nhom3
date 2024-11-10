using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShow.WebApp.Pages
{
    public class CompetitionModel : PageModel
    {
        private readonly ICompetitionRepository _competitionRepository;

        // Property to hold the list of competitions
        public List<Competition> Competitions { get; set; }

        // Constructor to inject the repository
        public CompetitionModel(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }
        public string LoggedInUser { get; set; }

        // OnGet method to retrieve competitions
        public async Task OnGet()
        {
            Competitions = await _competitionRepository.GetAllCompetitions();
            LoggedInUser = HttpContext.Session.GetString("LoggedInUser");
        }
    }
}
