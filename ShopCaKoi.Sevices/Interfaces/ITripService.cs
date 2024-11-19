using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Sevices.Interfaces
{
    public interface ITripService
    {
        IEnumerable<Trip> SearchTrips(string farmId, string koiId, float? minPrice, float? maxPrice, DateTime? departureDate);
        Task<List<Trip>> Trips();
        Boolean DelTrip(Trip infor);
        Boolean DelTrip(string id);
        Boolean AddTrip(Trip infor);
        Boolean UpdTrip(Trip infor);
        Task<Trip> GetTripById(string id);
        Boolean TripExists(string id);
        Task<IList<Trip>> GetTripsWithDetailsAsync();
        Task<List<Trip>> SearchTripsAsync(string? query, double? price, DateTime? date);
    }
}
