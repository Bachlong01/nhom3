using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShow.Repositories.Entities;

namespace KoiShow.Repositories.Interfaces
{
    public interface IKoicategoryRepository
    {
        Task<List<Koicategory>> GetAllKoicategories();
        Task<Koicategory> GetKoicategoryById(int id);
        bool AddKoicategory(Koicategory koicategory);
        bool UpdateKoicategory(Koicategory koicategory);
        bool DeleteKoicategory(int id);
    }
}
