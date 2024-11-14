using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.Services
{
	public class KoiService : IKoiService
	{
		private readonly IKoiRepository _repository;
		public KoiService(IKoiRepository repository)
		{
			_repository = repository;
		}

		public bool AddKoi(Koi infor)
		{
			return _repository.AddKoi(infor);
		}

		public bool DelKoi(Koi infor)
		{
			return _repository.DelKoi(infor);
		}

		public bool DelKoi(string id)
		{
			return _repository.DelKoi(id);
		}

        public Task<IEnumerable<Koi>> GetKoiByFarmIdAsync(string id)
        {
			return _repository.GetKoiByFarmIdAsync(id);
        }

        public Task<Koi> GetKoiById(string id)
		{
			return _repository.GetKoiById(id);
		}

		public Task<List<Koi>> GetKoisAsync()
		{
			return _repository.GetKoisAsync();
		}

		public bool KoiExists(string id)
		{
			return _repository.KoiExists(id);
		}

		public bool UpdKoi(Koi infor)
		{
			return _repository.UpdKoi(infor);
		}
	}
}
