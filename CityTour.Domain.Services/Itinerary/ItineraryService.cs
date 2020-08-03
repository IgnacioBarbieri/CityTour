using CityTour.Domain.Services.Itinerary;
using CityTour.Persistence.Core;
using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityTour.Domain.Services
{
    public class ItineararyService : PersistenceService<GuestItineraryPoint>, IItineararyService
    {
        public ItineararyService(IUnitOfWork unitOfWork, IRepository<GuestItineraryPoint> repository)
            : base(unitOfWork, repository) { }   
                
        public GuestItineraryPoint GetBydId(int Id)
        {
            return repository.QueryById(Id);
        }

        public IEnumerable<GuestItineraryPoint> GetRequestedPoints()
        {
            return repository.Query(x => x.Id != 1); // Hotel Bates
        }
      
        public IEnumerable<GuestItineraryPoint> ShowSummary(GuestItineraryPoint startPoint, GuestItineraryPoint endPoint)
        {           
            if (startPoint == null)
            {
                throw new ArgumentNullException(nameof(startPoint));
            }

            if (endPoint == null)
            {
                throw new ArgumentNullException(nameof(endPoint));
            }

            IEnumerable<GuestItineraryPoint> points = repository
                .Query(includeProperties: nameof(GuestItineraryPoint.Guests))
                .OrderBy(x => x.Id)
                .ToList();

            Graph<GuestItineraryPoint> graph = GraphFactory.CreateGraph(points);

            Node<GuestItineraryPoint> startNode = graph.Nodes?.SingleOrDefault(node => node?.Value?.Id == startPoint.Id);
            Node<GuestItineraryPoint> endNode = graph.Nodes?.SingleOrDefault(node => node?.Value?.Id == endPoint.Id);
            
            IEnumerable<Node<GuestItineraryPoint>> path = graph?.FindShortestPath(startNode, endNode);

            var result = path?.Select(item =>
            {
                item.Value.Distance = item.TentativeDistance;
                return item.Value;
            });
            
            return result;
        }  
    }
}
