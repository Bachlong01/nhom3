using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShow.Repositories.Entities;

namespace KoiShow.Service.Interfaces
{
    public interface IKoicategoryService
    {
        Task<List<Koicategory>> GetKoicategories();
        Task<Koicategory> GetKoicategoryById(int id);
        bool AddKoicategory(Koicategory koicategory);
        bool UpdateKoicategory(Koicategory koicategory);
        bool DeleteKoicategory(int id);
    }
}
