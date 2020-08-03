using System.Data.Entity;
using System.Threading.Tasks;

namespace CityTour.Persistence.Core
{
    public interface IEFUnitOfWork : IUnitOfWork
    {
        DbContext DBContext { get; }
    }
}