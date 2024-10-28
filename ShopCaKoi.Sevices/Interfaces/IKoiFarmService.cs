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
        Task<IEnumerable<KoiFarm>> GetKoiFarmsAsync();
    }
}
