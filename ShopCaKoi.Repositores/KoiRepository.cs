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
    public class KoiRepository : IKoiRepository
    {
        private readonly DataShopCaKoiContext _dbContext;
        public KoiRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<Koi>> GetKoisAsync()
        {
            return await _dbContext.Kois.ToListAsync();
        }
    }
}
