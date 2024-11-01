﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;

namespace ShopCaKoi.Repositores
{
    public class TripRepository : ITripRepository
    {
        private readonly DataShopCaKoiContext _dbContext;

        public TripRepository(DataShopCaKoiContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddTrip(Trip infor)
        {
            try
            {
                _dbContext.Trips.Add(infor);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }

        public bool DelTrip(Trip infor)
        {
            try
            {
                _dbContext.Trips.Remove(infor);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
                return false;
            }
        }

        public bool DelTrip(string id)
        {
            try
            {
                var ojbDel = _dbContext.Trips.Where(p => p.TripId.Equals(id)).FirstOrDefault();
                if (ojbDel != null)
                {
                    _dbContext.Trips.Remove(ojbDel);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<List<Trip>> GetAllTrip()
        {
            return await _dbContext.Trips.ToListAsync();
        }

        public async Task<Trip> GetTripById(string id)
        {
            return await _dbContext.Trips.Where(p => p.TripId.Equals(id)).FirstOrDefaultAsync();
        }

        public async Task<IList<Trip>> GetTripsWithDetailsAsync()
        {
            return await _dbContext.Trips
                .Include(t => t.Farm)
                .ThenInclude(t => t.Koi)
                .ToListAsync();
        }

        public IEnumerable<Trip> SearchTrips(string farmId, string koiId, float? minPrice, float? maxPrice, DateTime? departureDate)
        {
            var query = _dbContext.Trips.AsQueryable();

            if (!string.IsNullOrEmpty(farmId))
                query = query.Where(t => t.FarmId == farmId);

            if (!string.IsNullOrEmpty(koiId))
                query = query.Where(t => t.KoiId == koiId);

            if (minPrice.HasValue)
                query = query.Where(t => t.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(t => t.Price <= maxPrice.Value);

            if (departureDate.HasValue)
                query = query.Where(t => t.DepartureDate == DateOnly.FromDateTime(departureDate.Value));


            return query.ToList();
        }

        public async Task<List<Trip>> SearchTripsAsync(string keyword)
        {
            var trips = await _dbContext.Trips
                .Include(t => t.Farm)
                .ThenInclude(t => t.Koi)
                .Where(t => t.Farm.Name.ToUpper().Contains(keyword) || t.Farm.Koi.Species.ToUpper().Contains(keyword)).ToListAsync();
            return trips;

        }

        public bool TripExists(string id)
        {
            return _dbContext.Trips.Any(e => e.TripId == id);
        }

        public bool UpdTrip(Trip infor)
        {
            try
            {
                _dbContext.Trips.Update(infor);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
