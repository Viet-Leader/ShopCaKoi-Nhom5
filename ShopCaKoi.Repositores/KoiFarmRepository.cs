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
    public class KoiFarmRepository : IKoiFarmRepository
    {
        private readonly DataShopCaKoiContext _dbContext;
        public KoiFarmRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<KoiFarm>> GetKoiFarmsAsync()
        {
            return await _dbContext.KoiFarms.ToListAsync();
        }
    }
}
