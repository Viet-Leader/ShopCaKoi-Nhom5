using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.Sevices
{
    public class ShopCaKoiAccountService : IShopCaKoiAccountService
    {
        private readonly IShopCaKoiAccountRepository _repository;
        public ShopCaKoiAccountService(IShopCaKoiAccountRepository repository)
        {
            _repository = repository;
        }

        public bool AddShopCaKoiAccount(ShopCaKoiAccount account)
        {
            return _repository.AddShopCaKoiAccount(account);
        }

        public bool DelShopCaKoiAccount(ShopCaKoiAccount account)
        {
            return _repository.DelShopCaKoiAccount(account);
        }

        public bool DelShopCaKoiAccount(string id)
        {
            return _repository.DelShopCaKoiAccount(id);
        }

        public Task<ShopCaKoiAccount> GetShopCaKoiAccountById(string id)
        {
            return _repository.GetShopCaKoiAccountById(id);
        }

        public bool ShopCaKoiAccountExists(string id)
        {
            return _repository.ShopCaKoiAccountExists(id);
        }

        public Task<List<ShopCaKoiAccount>> ShopCaKoiAccounts()
        {
            return _repository.GetAllShopCaKoiAccount();
        }

        public bool UpdShopCaKoiAccount(ShopCaKoiAccount account)
        {
            return _repository.UpdShopCaKoiAccount(account);
        }
    }
}
