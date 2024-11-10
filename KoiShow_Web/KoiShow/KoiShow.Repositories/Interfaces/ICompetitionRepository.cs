using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShow.Repositories.Entities;

namespace KoiShow.Repositories.Interfaces
{
    public interface ICompetitionRepository
    {
        Task<List<Competition>> GetAllCompetitions();
        Task<Competition> GetCompetitionById(int id);
        bool AddCompetition(Competition competition);
        bool UpdateCompetition(Competition competition);
        bool DeleteCompetition(int id);
    }
}
