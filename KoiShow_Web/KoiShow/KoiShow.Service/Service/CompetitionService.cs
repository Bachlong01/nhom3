using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;
using KoiShow.Service.Interfaces;

namespace KoiShow.Service.Service
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _competitionRepository;

        public CompetitionService(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }

        public async Task<List<Competition>> GetCompetitions()
        {
            return await _competitionRepository.GetAllCompetitions();
        }

        public async Task<Competition> GetCompetitionById(int id)
        {
            return await _competitionRepository.GetCompetitionById(id);
        }

        public bool AddCompetition(Competition competition)
        {
            return _competitionRepository.AddCompetition(competition);
        }

        public bool UpdateCompetition(Competition competition)
        {
            return _competitionRepository.UpdateCompetition(competition);
        }

        public bool DeleteCompetition(int id)
        {
            return _competitionRepository.DeleteCompetition(id);
        }
    }
}
