using CityTour.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Validation;

namespace CityTour.Persistence.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CityTourContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CityTourContext context)
        {
            var guestItineraryPoints = new List<GuestItineraryPoint>
            {
                new GuestItineraryPoint { Name = "Hotel Bates (N0)" },
                new GuestItineraryPoint { Name = "Catedral de Jaén (N1)" },
                new GuestItineraryPoint { Name = "Castillo de Santa Catalina (N2)" },
                new GuestItineraryPoint { Name = "Centro Cultural Baños Árabes (N3)" },
                new GuestItineraryPoint { Name = "Arco de San Lorenzo (N4)" },
                new GuestItineraryPoint { Name = "Iglesia de San Bartolomé (N5)" }
            };

            context.ItineraryPoints.AddOrUpdate(guestItineraryPoints.ToArray());

            try
            {                
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
