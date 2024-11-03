using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores;
using ShopCaKoi.Repositores.Entities;
using System.Globalization;

namespace ShopCaKoi.Services
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _guestRepository;

        public GuestService(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository;
        }

        public List<KoiFarm> GetAllKoiFarmsInJapan()
        {
            return _guestRepository.GetAllKoiFarmsInJapan();
        }

        public List<Koi> GetKoiBreedsByFarm(string farmId)
        {
            return _guestRepository.GetAllKoiBreedsByFarm(farmId);
        }

        public KoiFarm GetFarmDetails(string farmId)
        {
            return _guestRepository.GetFarmDetails(farmId);
        }

        public Koi GetKoiDetails(string koiId)
        {
            return _guestRepository.GetKoiDetails(koiId);
        }

        public List<Trip> GetAllKoiFarmTours()
        {
            return _guestRepository.GetAllKoiFarmTours();
        }

        public List<Trip> FilterTours(string farmId, string priceRange, string koiType, DateTime? date)
        {
            return _guestRepository.FilterTours(farmId, priceRange, koiType, date);
        }

        public bool RegisterGuestAccount(ShopCaKoiAccount account)
        {
            return _guestRepository.CreateAccount(account);
        }
    }
}
