using ShopCaKoi.Repositores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCaKoi.Repositores.Interfaces
{
    public interface IQuotationRepository
    {
        Task<List<Quotation>> GetAllQuotations();

    }
}
