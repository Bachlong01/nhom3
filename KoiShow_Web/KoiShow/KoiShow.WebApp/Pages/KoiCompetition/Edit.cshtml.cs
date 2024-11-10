using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCompetition
{
    public class EditModel : PageModel
    {
        private readonly KoiShow.Repositories.Entities.KoiShow2024Context _context;

        public EditModel(KoiShow.Repositories.Entities.KoiShow2024Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Competition Competition { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Competition = await _context.Competitions.FirstOrDefaultAsync(m => m.CompetitionId == id);
            if (Competition == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Competition).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetitionExists(Competition.CompetitionId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool CompetitionExists(int id)
        {
            return _context.Competitions.Any(e => e.CompetitionId == id);
        }
    }
}
