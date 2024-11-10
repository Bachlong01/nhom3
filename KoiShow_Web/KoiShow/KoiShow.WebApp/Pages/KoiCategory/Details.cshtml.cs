using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCategory
{
    public class DetailsModel : PageModel
    {
        private readonly IKoicategoryService _service;

        public DetailsModel(IKoicategoryService service)
        {
            _service = service;
        }

        public Koicategory Koicategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Sử dụng dịch vụ để lấy danh mục
            Koicategory = await _service.GetKoicategoryById(id.Value);
            if (Koicategory == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
