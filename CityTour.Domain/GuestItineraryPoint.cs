using System.Collections.Generic;

namespace CityTour.Domain
{
    public class GuestItineraryPoint : ItineraryPoint
    {       
        public GuestItineraryPoint()
        {
            Guests = new List<Guest>();
        } 

        public int Distance { get; set; }

        public IList<Guest> Guests 
        {
            get;
            set;
        }
    }
}
