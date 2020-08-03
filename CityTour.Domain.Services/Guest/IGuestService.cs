
namespace CityTour.Domain.Services
{
    public interface IGuestService : IPersistenceService<Guest>
    {
        Guest GetById(int Id);
    }
}