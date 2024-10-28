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
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _repository;
        public KoiService(IKoiRepository repository)
        {
            _repository = repository;
        }

        public Task<IEnumerable<Koi>> GetKoisAsync()
        {
            return _repository.GetKoisAsync();
        }
    }
}
