using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Sevices.Interfaces
{
    public interface IKoiService
    {
		Task<List<Koi>> GetKoisAsync();
		Boolean DelKoi(Koi infor);
		Boolean DelKoi(string id);
		Boolean AddKoi(Koi infor);
		Boolean UpdKoi(Koi infor);
		Boolean KoiExists(string id);
		Task<Koi> GetKoiById(string id);
	}
}
