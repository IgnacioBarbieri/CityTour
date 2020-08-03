using CityTour.Persistence.Core;

namespace CityTour.Persistence
{
    public class CityTourUnitOfWork : EFUnitOfWork
    {
        public CityTourUnitOfWork(CityTourContext context) 
            : base(context) { }
    }
}
