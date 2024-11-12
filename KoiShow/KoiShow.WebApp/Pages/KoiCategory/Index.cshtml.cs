using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Service.Interfaces;

namespace KoiShow.WebApp.Pages.KoiCategory
{
    public class IndexModel : PageModel
    {
        private readonly IKoicategoryService _service;

        public IndexModel(IKoicategoryService service)
        {
            _service = service;
        }

        public IList<Koicategory> Koicategory { get; set; } = default!;

        public async Task OnGetAsync()
        {
            // Sử dụng dịch vụ để lấy danh sách danh mục
            Koicategory = await _service.GetKoicategories();
        }
    }
}
