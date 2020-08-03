using CityTour.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CityTour.Persistence.Configurations
{
    internal class GuestItineraryRequestConfiguration : EntityTypeConfiguration<GuestItineraryRequest>
    {
        public GuestItineraryRequestConfiguration()
        {
            this.HasRequired(s => s.EndPoint);
        }
    }
}
