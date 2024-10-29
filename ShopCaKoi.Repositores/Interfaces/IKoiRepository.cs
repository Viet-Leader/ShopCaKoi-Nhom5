using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Repositores.Interfaces
{
    public interface IKoiRepository
    {
        Task<IEnumerable<Koi>> GetKoisAsync();
    }
}
