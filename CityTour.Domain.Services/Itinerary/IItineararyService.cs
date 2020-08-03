using System.Collections.Generic;

namespace CityTour.Domain.Services
{
    public interface IItineararyService : IPersistenceService<GuestItineraryPoint> 
    {
        GuestItineraryPoint GetBydId(int Id);

        IEnumerable<GuestItineraryPoint> GetRequestedPoints();

        IEnumerable<GuestItineraryPoint> ShowSummary(GuestItineraryPoint startPoint, GuestItineraryPoint endPoint);
    }
}