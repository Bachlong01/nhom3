using KoiShow.Repositories.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KoiShow.Repositories.Interfaces
{
    public interface IKoiShowAccountService
    {
        Task<Koishowaccount?> GetByUsernameAsync(string username);
        Task<List<Koishowaccount>> GetKoishowaccountsAsync(); // Đổi tên để thể hiện phương thức bất đồng bộ
        Task<bool> DelKoishowaccountAsync(int id); // Chuyển đổi về Task<bool>
        Task<bool> DelKoishowaccountAsync(Koishowaccount account); // Chuyển đổi về Task<bool>
        Task<bool> AddKoishowaccountAsync(Koishowaccount account); // Chuyển đổi về Task<bool>
        Task<bool> UpdKoishowaccountAsync(Koishowaccount account); // Chuyển đổi về Task<bool>
        Task<Koishowaccount> GetKoishowaccountByIdAsync(int id); // Đổi tên để thể hiện phương thức bất đồng bộ
    
    }
}
