using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShow.Repositories.Entities;

namespace KoiShow.Service.Interfaces
{
    public interface ICompetitionService
    {
        Task<List<Competition>> GetCompetitions();
        Task<Competition> GetCompetitionById(int id);
        bool AddCompetition(Competition competition);
        bool UpdateCompetition(Competition competition);
        bool DeleteCompetition(int id);
    }
}
