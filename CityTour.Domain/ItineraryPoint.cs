using System.Collections.Generic;

namespace CityTour.Domain
{
    public abstract class ItineraryPoint
    {
        public int Id {get;set;}

        public string Name { get; set; }

        public string Description { get; set; }                      
    }
}
