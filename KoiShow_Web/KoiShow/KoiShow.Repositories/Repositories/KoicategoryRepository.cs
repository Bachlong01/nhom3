using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiShow.Repositories
{
    public class KoicategoryRepository : IKoicategoryRepository
    {
        private readonly KoiShow2024Context _context;

        public KoicategoryRepository(KoiShow2024Context context)
        {
            _context = context;
        }

        public async Task<List<Koicategory>> GetAllKoicategories()
        {
            return await _context.Koicategories.ToListAsync();
        }

        public async Task<Koicategory> GetKoicategoryById(int id)
        {
            return await _context.Koicategories.FindAsync(id);
        }

        public bool AddKoicategory(Koicategory koicategory)
        {
            _context.Koicategories.Add(koicategory);
            return _context.SaveChanges() > 0; // Trả về true nếu có thay đổi
        }

        public bool UpdateKoicategory(Koicategory koicategory)
        {
            _context.Koicategories.Update(koicategory);
            return _context.SaveChanges() > 0; // Trả về true nếu có thay đổi
        }

        public bool DeleteKoicategory(int id)
        {
            var koicategory = _context.Koicategories.Find(id);
            if (koicategory != null)
            {
                _context.Koicategories.Remove(koicategory);
                return _context.SaveChanges() > 0; // Trả về true nếu có thay đổi
            }
            return false;
        }
    }
}
