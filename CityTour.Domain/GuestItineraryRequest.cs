using System.Collections.Generic;


namespace CityTour.Domain
{
    public class GuestItineraryRequest        
    {
        public int Id { get; set; }
        
        public GuestItineraryPoint EndPoint { get; set; }
    }
}
