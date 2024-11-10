using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShow.Repositories.Repositories
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly KoiShow2024Context _dbcontext;

        public CompetitionRepository(KoiShow2024Context dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public async Task<List<Competition>> GetAllCompetitions()
        {
            return await _dbcontext.Competitions.ToListAsync();
        }

        public async Task<Competition> GetCompetitionById(int id)
        {
            return await _dbcontext.Competitions.FindAsync(id);
        }

        public bool AddCompetition(Competition competition)
        {
            _dbcontext.Competitions.Add(competition);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool UpdateCompetition(Competition competition)
        {
            _dbcontext.Competitions.Update(competition);
            _dbcontext.SaveChanges();
            return true;
        }

        public bool DeleteCompetition(int id)
        {
            var competition = _dbcontext.Competitions.Find(id);
            if (competition != null)
            {
                _dbcontext.Competitions.Remove(competition);
                _dbcontext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
