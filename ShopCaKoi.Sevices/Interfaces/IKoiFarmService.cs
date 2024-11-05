using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Sevices.Interfaces
{
    public interface IKoiFarmService
    {
		Task<List<KoiFarm>> GetKoiFarmsAsync();
		Boolean DelKoiFarm(KoiFarm infor);
		Boolean DelKoiFarm(string id);
		Boolean AddKoiFarm(KoiFarm infor);
		Boolean UpdKoiFarm(KoiFarm infor);
		Boolean KoiFarmExists(string id);
		Task<KoiFarm> GetKoiFarmById(string id);
	}
}
