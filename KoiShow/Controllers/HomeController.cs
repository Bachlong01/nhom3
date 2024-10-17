using KoiShow.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KoiShow.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult TrangChu()
		{
			return View();
		}
        public IActionResult DangKy()
        {
            return View();
        }
        public IActionResult DangNhap()
        {
            return View();
        }
        public IActionResult TTChiTietCuocThi()
        {
            return View();
        }
		public IActionResult ThemCaKoi()
		{
			return View();
		}
		public IActionResult DangXuat()
		{
			return View();
		}
		public IActionResult TrangCaNhan()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
