using System.Threading.Tasks;

namespace CityTour.Persistence.Core
{
    public interface IUnitOfWork
    {
        void Commit();
        Task CommitAsync();
        void Dispose();
    }
}