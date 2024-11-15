using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores;
using ShopCaKoi.Repositores.Entities;
using ShopCaKoi.Repositores.Interfaces;
using ShopCaKoi.Sevices.Interfaces;

namespace ShopCaKoi.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _repository;
        public TripService(ITripRepository repository)
        {
            _repository = repository;
        }

        public bool AddTrip(Trip infor)
        {
            return _repository.AddTrip(infor);
        }

        public bool DelTrip(Trip infor)
        {
            return _repository.DelTrip(infor);
        }

        public bool DelTrip(string id)
        {
            return _repository.DelTrip(id);
        }

        public Task<List<Trip>> Trips()
        {
            return _repository.GetAllTrip();
        }

        public Task<Trip> GetTripById(string id)
        {
            return _repository.GetTripById(id);
        }

        public IEnumerable<Trip> SearchTrips(string farmId, string koiId, float? minPrice, float? maxPrice, DateTime? departureDate)
        {
            return _repository.SearchTrips(farmId, koiId, minPrice, maxPrice, departureDate);
        }

        public bool TripExists(string id)
        {
            return _repository.TripExists(id);
        }

        public bool UpdTrip(Trip infor)
        {
            return _repository.UpdTrip(infor);
        }

        public Task<IList<Trip>> GetTripsWithDetailsAsync()
        {
            return _repository.GetTripsWithDetailsAsync();
        }

        public Task<IEnumerable<Trip>> SearchTripsAsync(string keyword, double? price, DateTime? startDate, DateTime? endDate)
        {
            return _repository.SearchTripsAsync(keyword,price,startDate,endDate);
        }
    }
}
