using CityTour.Persistence.Core;
using System;
using System.Xml.Linq;

namespace CityTour.Domain.Services
{
    public class GuestService : PersistenceService<Guest>, IGuestService
    {
        public GuestService(IUnitOfWork unitOfWork, IRepository<Guest> repository)
            : base(unitOfWork, repository) { }

        public Guest GetById(int Id)
        {
            return repository.QueryById(Id);
        }

    }
}
