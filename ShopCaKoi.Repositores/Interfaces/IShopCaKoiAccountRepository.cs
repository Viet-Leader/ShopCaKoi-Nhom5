using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Repositores.Interfaces
{
    public interface IShopCaKoiAccountRepository
    {
        Task<List<ShopCaKoiAccount>> GetAllShopCaKoiAccount();
        Boolean DelShopCaKoiAccount(ShopCaKoiAccount account);
        Boolean DelShopCaKoiAccount(string id);
        Boolean AddShopCaKoiAccount(ShopCaKoiAccount account);
        Boolean UpdShopCaKoiAccount(ShopCaKoiAccount account);
        Task<ShopCaKoiAccount> GetShopCaKoiAccountById(string id);
        Boolean ShopCaKoiAccountExists(string id);
    }
}
