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
    public class KoiFarmService : IKoiFarmService
    {
        private readonly IKoiFarmRepository _repository;
        public KoiFarmService(IKoiFarmRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<KoiFarm>> GetKoiFarmsAsync()
        {
            return _repository.GetKoiFarmsAsync();
        }
    }
}
