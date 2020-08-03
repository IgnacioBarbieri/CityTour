using System.Collections.Generic;

namespace CityTour.Domain
{
    public class Itinerary
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ItineraryPoint> Points { get; set; }
    }
}
