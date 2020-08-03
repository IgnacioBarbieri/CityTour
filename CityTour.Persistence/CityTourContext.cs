using CityTour.Domain;
using CityTour.Persistence.Configurations;
using System.Data.Entity;

namespace CityTour.Persistence
{
    public class CityTourContext : DbContext
    {        
        public CityTourContext() : base("LocalDbConnection")
        {
            #if DEBUG
                var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
            #endif
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GuestConfiguration());
            modelBuilder.Configurations.Add(new GuestItineraryRequestConfiguration());
            modelBuilder.Configurations.Add(new GuestItineraryPointConfiguration());            
        }

        public DbSet<Guest> Guests { get; set; }

        public DbSet<ItineraryPoint> ItineraryPoints { get; set; }

        public DbSet<GuestItineraryRequest> GuestItineraryRequests { get; set; }
    }

}


