using KoiShow.Repositories.Entities;
using KoiShow.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoiShow.Repositories.Repositories
{
    public class KoiShowAccountRepository : IKoiShowAccountRepository
    {
        private readonly KoiShow2024Context _dbContext;

        public KoiShowAccountRepository(KoiShow2024Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Koishowaccount>> GetAllKoiShowAccountAsync()
        {
            return await _dbContext.Koishowaccounts.ToListAsync();
        }

        public async Task<bool> DelKoishowaccountAsync(int id)
        {
            try
            {
                var objDel = await _dbContext.Koishowaccounts.FindAsync(id);
                if (objDel != null)
                {
                    _dbContext.Koishowaccounts.Remove(objDel);
                    await _dbContext.SaveChangesAsync(); // Sử dụng SaveChangesAsync
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false; // Trả về false nếu có lỗi
            }
        }

        public async Task<bool> DelKoishowaccountAsync(Koishowaccount account)
        {
            try
            {
                _dbContext.Koishowaccounts.Remove(account);
                await _dbContext.SaveChangesAsync(); // Sử dụng SaveChangesAsync
                return true;
            }
            catch (Exception)
            {
                return false; // Trả về false nếu có lỗi
            }
        }

        public async Task<bool> AddKoishowaccountAsync(Koishowaccount account)
        {
            try
            {
                // Kiểm tra AccountId đã tồn tại hay chưa
                bool accountIdExists = await _dbContext.Koishowaccounts
                    .AnyAsync(a => a.AccountId == account.AccountId);

                if (accountIdExists)
                {
                    return false; // AccountId đã tồn tại, không thể thêm
                }

                // Kiểm tra Username đã tồn tại hay chưa
                bool usernameExists = await _dbContext.Koishowaccounts
                    .AnyAsync(a => a.Username == account.Username);

                if (usernameExists)
                {
                    return false; // Username đã tồn tại, không thể thêm
                }

                // Thêm tài khoản mới vào cơ sở dữ liệu
                await _dbContext.Koishowaccounts.AddAsync(account); // Sử dụng AddAsync
                await _dbContext.SaveChangesAsync(); // Sử dụng SaveChangesAsync
                return true;
            }
            catch (Exception)
            {
                return false; // Trả về false nếu có lỗi
            }
        }

        public async Task<bool> UpdKoishowaccountAsync(Koishowaccount account)
        {
            try
            {
                _dbContext.Koishowaccounts.Update(account);
                await _dbContext.SaveChangesAsync(); // Sử dụng SaveChangesAsync
                return true;
            }
            catch (Exception)
            {
                return false; // Trả về false nếu có lỗi
            }
        }

        public async Task<Koishowaccount> GetKoishowaccountByIdAsync(int id)
        {
            return await _dbContext.Koishowaccounts.FindAsync(id); // Sử dụng FindAsync để tìm kiếm theo Id
        }
        public async Task<Koishowaccount?> GetByUsernameAsync(string username)
        {
            return await _dbContext.Koishowaccounts
                .FirstOrDefaultAsync(a => a.Username == username);
        }
    }
}
