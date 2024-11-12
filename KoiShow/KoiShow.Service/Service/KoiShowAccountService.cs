using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;

namespace KoiShow.Service.Service
{
    public class KoiShowAccountService : IKoiShowAccountService
    {
        private readonly IKoiShowAccountRepository _repository;

        public KoiShowAccountService(IKoiShowAccountRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Koishowaccount>> GetKoishowaccountsAsync()
        {
            return await _repository.GetAllKoiShowAccountAsync(); // Lấy danh sách tài khoản
        }

        public async Task<bool> DelKoishowaccountAsync(int id)
        {
            return await _repository.DelKoishowaccountAsync(id); // Xóa tài khoản theo ID
        }

        public async Task<bool> DelKoishowaccountAsync(Koishowaccount account)
        {
            return await _repository.DelKoishowaccountAsync(account); // Xóa tài khoản theo đối tượng
        }

        public async Task<bool> AddKoishowaccountAsync(Koishowaccount account)
        {
            return await _repository.AddKoishowaccountAsync(account); // Thêm tài khoản mới
        }

        public async Task<bool> UpdKoishowaccountAsync(Koishowaccount account)
        {
            return await _repository.UpdKoishowaccountAsync(account); // Cập nhật tài khoản
        }

        public async Task<Koishowaccount> GetKoishowaccountByIdAsync(int id)
        {
            return await _repository.GetKoishowaccountByIdAsync(id); // Lấy tài khoản theo ID
        }
        public async Task<Koishowaccount?> GetByUsernameAsync(string username)
        {
            return await _repository.GetByUsernameAsync(username); // Gọi từ repository
        }

    }
}
