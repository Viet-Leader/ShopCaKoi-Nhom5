using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCaKoi.Sevices
{
    public class QuotationService : IQuotationService
    {
        private readonly IQuotationRepository _quotationRepository;

        public QuotationService(IQuotationRepository quotationRepository)
        {
            _quotationRepository = quotationRepository;
        }

        // Triển khai phương thức GetAllQuotations() để khớp với interface
        public async Task<List<Quotation>> GetAllQuotations()
        {
            return await _quotationRepository.GetAllQuotations();
        }
    }
}
