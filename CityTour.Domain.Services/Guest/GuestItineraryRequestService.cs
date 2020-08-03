using CityTour.Persistence.Core;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace CityTour.Domain.Services
{
    public class GuestItineararyRequestService : PersistenceService<GuestItineraryRequest>, IGuestItineararyRequestService
    {
        public GuestItineararyRequestService(IUnitOfWork unitOfWork, IRepository<GuestItineraryRequest> repository)
            : base(unitOfWork, repository) { }

        public override IEnumerable<GuestItineraryRequest> GetAll()
        {
            return repository.Query(includeProperties: nameof(GuestItineraryRequest.EndPoint));
        }

    }
}
