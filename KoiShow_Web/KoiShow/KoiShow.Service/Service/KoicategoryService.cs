using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;
using KoiShow.Service.Interfaces;

namespace KoiShow.Service.Service
{
    public class KoicategoryService : IKoicategoryService
    {
        private readonly IKoicategoryRepository _koicategoryRepository;

        public KoicategoryService(IKoicategoryRepository koicategoryRepository)
        {
            _koicategoryRepository = koicategoryRepository;
        }

        public async Task<List<Koicategory>> GetKoicategories()
        {
            return await _koicategoryRepository.GetAllKoicategories();
        }

        public async Task<Koicategory> GetKoicategoryById(int id)
        {
            return await _koicategoryRepository.GetKoicategoryById(id);
        }

        public bool AddKoicategory(Koicategory koicategory)
        {
            return _koicategoryRepository.AddKoicategory(koicategory);
        }

        public bool UpdateKoicategory(Koicategory koicategory)
        {
            return _koicategoryRepository.UpdateKoicategory(koicategory);
        }

        public bool DeleteKoicategory(int id)
        {
            return _koicategoryRepository.DeleteKoicategory(id);
        }
    }
}
