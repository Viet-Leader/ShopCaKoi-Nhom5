using ShopCaKoi.Repositores.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCaKoi.Sevices.Interfaces
{
    public interface IQuotationService
    {
        Task<List<Quotation>> GetAllQuotations();
    }
}
