using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;

namespace KoiShow.WebApp.Pages.Account
{
    public class IndexModel : PageModel
    {
        private readonly IKoiShowAccountService _service; // Service để tương tác với tài khoản

        public IndexModel(IKoiShowAccountService service)
        {
            _service = service; // Tiêm service
        }

        public IList<Koishowaccount> Koishowaccount { get; set; } = default!; // Danh sách tài khoản

        public async Task OnGetAsync() // Phương thức xử lý yêu cầu GET
        {
            Koishowaccount = await _service.GetKoishowaccountsAsync(); // Lấy danh sách tài khoản từ service
        }
    }
}
