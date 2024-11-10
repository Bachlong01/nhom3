using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCategory
{
    public class DeleteModel : PageModel
    {
        private readonly IKoicategoryService _service;

        public DeleteModel(IKoicategoryService service)
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
            var koicategory = await _service.GetKoicategoryById(id.Value);
            if (koicategory == null)
            {
                return NotFound();
            }

            Koicategory = koicategory;
            return Page();
        }

        public IActionResult OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = _service.DeleteKoicategory(id.Value); // Gọi phương thức xóa

            if (result) // Kiểm tra xem việc xóa có thành công không
            {
                return RedirectToPage("./Index");
            }

            // Nếu không thành công, bạn có thể thêm thông báo lỗi hoặc xử lý khác
            ModelState.AddModelError(string.Empty, "Không thể xóa danh mục. Vui lòng thử lại.");
            return Page();
        }
    }
}
