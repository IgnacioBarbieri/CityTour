using CityTour.Domain;
using System.Data.Entity.ModelConfiguration;

namespace CityTour.Persistence.Configurations
{
    internal class GuestConfiguration : EntityTypeConfiguration<Guest>
    {
        public GuestConfiguration()
        {
            this.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(s => s.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(s => s.LastName)
                .IsOptional() 
                .HasMaxLength(50);
                           
        }
    }
}
