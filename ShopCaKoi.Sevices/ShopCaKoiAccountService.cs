using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.Sevices
{
    public class ShopCaKoiAccountService : IShopCaKoiAccountService
    {
        private readonly ShopCaKoiAccountRepository _repository;
        public ShopCaKoiAccountService(ShopCaKoiAccountRepository repository)
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

        public bool DelShopCaKoiAccount(string Id)
        {
            return _repository.DelShopCaKoiAccount(Id);
        }

        public Task<List<ShopCaKoiAccount>> ShopCaKoiAccounts()
        {
            return _repository.GetAllShopCaKoiAccount();
        }

        public Task<ShopCaKoiAccount> GetShopCaKoiAccountById(string Id)
        {
            return _repository.GetShopCaKoiAccountById(Id);
        }

        public bool UpdShopCaKoiAccount(ShopCaKoiAccount account)
        {
            return _repository.UpdShopCaKoiAccount(account);
        }

        public bool ShopCaKoiAccountExists(string Id)
        {
            return _repository.ShopCaKoiAccountExists(Id);
        }
    }   
}
