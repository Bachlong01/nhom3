using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiShow.WebApp.Pages
{
    public class MyProfileModel : PageModel
    {
        private readonly ICompetitionRepository _competitionRepository;
        private readonly IKoicategoryRepository _koicategoryRepository;

        // Các thuộc tính để chứa dữ liệu cần thiết
        public List<Competition> Competitions { get; set; }
        public List<Koicategory> Koicategories { get; set; }

        // Property để chứa tên người dùng đã đăng nhập
        public string LoggedInUser { get; set; }

        // Constructor để inject cả hai repository
        public MyProfileModel(ICompetitionRepository competitionRepository, IKoicategoryRepository koicategoryRepository)
        {
            _competitionRepository = competitionRepository;
            _koicategoryRepository = koicategoryRepository;
        }

        // Phương thức OnGetAsync để lấy tất cả thể loại cá và tên người dùng khi trang được load
        public async Task OnGetAsync()
        {
            // Lấy danh sách cuộc thi và thể loại cá từ cơ sở dữ liệu
            Competitions = await _competitionRepository.GetAllCompetitions();
            Koicategories = await _koicategoryRepository.GetAllKoicategories();

            // Lấy tên người dùng đã đăng nhập từ session
            LoggedInUser = HttpContext.Session.GetString("LoggedInUser");
        }
    }
}
