using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCategory
{
    public class CreateModel : PageModel
    {
        private readonly IKoicategoryService _service;

        public CreateModel(IKoicategoryService service)
        {
            _service = service;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Koicategory Koicategory { get; set; } = default!;

        public IActionResult OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Gọi phương thức để thêm danh mục
            var result = _service.AddKoicategory(Koicategory); // Không cần await

            if (result) // Kiểm tra xem việc thêm có thành công không
            {
                return RedirectToPage("./Index");
            }

            // Nếu không thành công, bạn có thể thêm thông báo lỗi hoặc xử lý khác
            ModelState.AddModelError(string.Empty, "Không thể thêm danh mục. Vui lòng thử lại.");
            return Page();
        }
    }
}
