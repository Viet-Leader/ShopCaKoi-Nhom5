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

		public bool AddKoiFarm(KoiFarm infor)
		{
			return _repository.AddKoiFarm(infor);
		}

		public bool DelKoiFarm(KoiFarm infor)
		{
			return _repository.DelKoiFarm(infor);
		}

		public bool DelKoiFarm(string id)
		{
			return _repository.DelKoiFarm(id);
		}

		public Task<KoiFarm> GetKoiFarmById(string id)
		{
			return _repository.GetKoiFarmById(id);
		}

		public Task<List<KoiFarm>> GetKoiFarmsAsync()
		{
			return _repository.GetKoiFarmsAsync();
		}

		public bool KoiFarmExists(string id)
		{
			return _repository.KoiFarmExists(id);
		}

		public bool UpdKoiFarm(KoiFarm infor)
		{
			return _repository.UpdKoiFarm(infor);
		}
	}
}
