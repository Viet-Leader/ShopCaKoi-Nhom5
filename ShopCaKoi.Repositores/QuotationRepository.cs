using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ShopCaKoi.Repositores
{
    public class QuotationRepository : IQuotationRepository
    {
        private readonly DataShopCaKoiContext _dbContext;

        public QuotationRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Triển khai phương thức GetAllQuotations() theo interface
        public async Task<List<Quotation>> GetAllQuotations()
        {
            return await _dbContext.Quotations.ToListAsync();
        }
    }
}
