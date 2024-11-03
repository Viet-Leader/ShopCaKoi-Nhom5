using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using System.Globalization;

namespace ShopCaKoi.Repositores
{
    public class GuestRepository : IGuestRepository
    {
        private readonly DataShopCaKoiContext _context;

        public GuestRepository(DataShopCaKoiContext context)
        {
            _context = context;
        }

        public List<KoiFarm> GetAllKoiFarmsInJapan()
        {
            return _context.KoiFarms
                           .Where(farm => farm.Location == "Japan")
                           .ToList();
        }

        public List<Koi> GetAllKoiBreedsByFarm(string farmId)
        {
            return _context.Kois
                           .Where(koi => koi.KoiFarms.Any(farm => farm.FarmId == farmId))
                           .ToList();
        }

        public KoiFarm GetFarmDetails(string farmId)
        {
            return _context.KoiFarms
                           .Include(f => f.Koi)
                           .FirstOrDefault(f => f.FarmId == farmId);
        }

        public Koi GetKoiDetails(string koiId)
        {
            return _context.Kois
                           .Include(k => k.KoiFarms)
                           .FirstOrDefault(k => k.KoiId == koiId);
        }

        public List<Trip> GetAllKoiFarmTours()
        {
            return _context.Trips.ToList();
        }

        public List<Trip> FilterTours(string farmId, string priceRange, string koiType, DateTime? date)
        {
            var query = _context.Trips.AsQueryable();

            if (!string.IsNullOrEmpty(farmId))
                query = query.Where(t => t.FarmId == farmId);

            if (!string.IsNullOrEmpty(priceRange))
            {
                var prices = priceRange.Split('-').Select(double.Parse).ToArray();
                query = query.Where(t => t.Price >= prices[0] && t.Price <= prices[1]);
            }

            if (!string.IsNullOrEmpty(koiType))
                query = query.Where(t => t.Koi.Species == koiType);

            if (date.HasValue)
                query = query.Where(t => t.DepartureDate == DateOnly.FromDateTime(date.Value));

            return query.ToList();
        }

        public bool CreateAccount(ShopCaKoiAccount account)
        {
            _context.ShopCaKoiAccounts.Add(account);
            return _context.SaveChanges() > 0;
        }
    }
}
