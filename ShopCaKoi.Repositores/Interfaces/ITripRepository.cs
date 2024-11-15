using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopCaKoi.Repositores.Entities;

namespace ShopCaKoi.Repositores.Interfaces
{
    public interface ITripRepository
    {
        IEnumerable<Trip> SearchTrips(string farmId, string koiId, float? minPrice, float? maxPrice, DateTime? departureDate);
        Task<List<Trip>> GetAllTrip();
        Boolean DelTrip(Trip infor);
        Boolean DelTrip(string id);
        Boolean AddTrip(Trip infor);
        Boolean UpdTrip(Trip infor);
        Task<Trip> GetTripById(string id);
        Boolean TripExists(string id);
        Task<IList<Trip>> GetTripsWithDetailsAsync();
        Task<IEnumerable<Trip>> SearchTripsAsync(string keyword, double? price, DateTime? startDate, DateTime? endDate);

    }
}
