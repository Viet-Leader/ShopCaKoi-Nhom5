using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;

namespace ShopCaKoi.Repositores
{
    public class ShopCaKoiAccountRepository : IShopCaKoiAccountRepository

    {
        private readonly DataShopCaKoiContext _dbContext;
        public ShopCaKoiAccountRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddShopCaKoiAccount(ShopCaKoiAccount account)
        {
            try
            {
                _dbContext.ShopCaKoiAccounts.Add(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool DelShopCaKoiAccount(ShopCaKoiAccount account)
        {
            try
            {
                _dbContext.ShopCaKoiAccounts.Remove(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
                return false;
            }
        }

        public bool DelShopCaKoiAccount(string Id)
        {
            try
            {
                var ojbDel = _dbContext.ShopCaKoiAccounts.Where(p => p.AccId.Equals(Id)).FirstOrDefault();
                if (ojbDel != null)
                {
                    _dbContext.ShopCaKoiAccounts.Remove(ojbDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<ShopCaKoiAccount>> GetAllShopCaKoiAccount()
        {
            return await _dbContext.ShopCaKoiAccounts.ToListAsync();
        }

        public async Task<ShopCaKoiAccount> GetShopCaKoiAccountById(string Id)
        {
            return await _dbContext.ShopCaKoiAccounts.Where(p => p.AccId.Equals(Id)).FirstOrDefaultAsync(); 
        }

        public bool ShopCaKoiAccountExists(string Id)
        {
            return _dbContext.ShopCaKoiAccounts.Any(e => e.AccId == Id);
        }

        public bool UpdShopCaKoiAccount(ShopCaKoiAccount account)
        {
            try
            {
                _dbContext.ShopCaKoiAccounts.Update(account);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
        

}
