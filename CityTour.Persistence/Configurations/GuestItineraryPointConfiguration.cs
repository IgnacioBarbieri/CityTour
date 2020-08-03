using CityTour.Domain;
using System.Data.Entity.ModelConfiguration;
using System.Security.Policy;

namespace CityTour.Persistence.Configurations
{
    internal class GuestItineraryPointConfiguration : EntityTypeConfiguration<GuestItineraryPoint>
    {
        public GuestItineraryPointConfiguration()
        {
            this.Property(s => s.Name)
               .IsRequired()
               .HasMaxLength(50);

            this.Property(s => s.Description)
                .IsOptional()
                .HasMaxLength(200);

            this.Ignore(s => s.Distance);

            this.HasMany(s => s.Guests);

            this.ToTable("GuestItineraryPoints");            
        }
    }
}
