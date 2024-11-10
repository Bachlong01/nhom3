using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCategory
{
    public class EditModel : PageModel
    {
        private readonly IKoicategoryService _service;

        public EditModel(IKoicategoryService service)
        {
            _service = service;
        }

        [BindProperty]
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

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Gọi phương thức cập nhật danh mục từ dịch vụ
            var result = _service.UpdateKoicategory(Koicategory);
            if (result)
            {
                return RedirectToPage("./Index");
            }

            ModelState.AddModelError(string.Empty, "Không thể cập nhật danh mục. Vui lòng thử lại.");
            return Page();
        }
    }
}
