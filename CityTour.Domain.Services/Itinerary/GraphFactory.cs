using GraphLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CityTour.Domain.Services.Itinerary
{
    public class GraphFactory
    {

        // PREDEFINED Graph Edges
        //node0.AddEdge(node1, 5);
        //node0.AddEdge(node4, 3);

        //node1.AddEdge(node5, 6);
        //node1.AddEdge(node3, 3);
        //node1.AddEdge(node2, 8);

        //node2.AddEdge(node4, 7);
        //node2.AddEdge(node3, 4);

        //node3.AddEdge(node4, 2);
        //node3.AddEdge(node5, 8);

        //node4.AddEdge(node5, 9);

        public static Graph<GuestItineraryPoint> CreateGraph (IEnumerable<GuestItineraryPoint> points)
        {
            if (points == null)
            {
                throw new ArgumentNullException(nameof(points));
            }

            List<Node<GuestItineraryPoint>> nodes = new List<Node<GuestItineraryPoint>>();

            IDictionary<int, List<Neighbour<int>>> edges = new Dictionary<int, List<Neighbour<int>>>();
            edges.Add(1, new List<Neighbour<int>> 
            { 
                new Neighbour<int>(new Node<int>(2), 5),
                new Neighbour<int>(new Node<int>(5), 3),
            });
            edges.Add(2, new List<Neighbour<int>>
            {
                new Neighbour<int>(new Node<int>(6), 6),
                new Neighbour<int>(new Node<int>(4), 3),
                new Neighbour<int>(new Node<int>(3), 8),
            });
            edges.Add(3, new List<Neighbour<int>>
            {
                new Neighbour<int>(new Node<int>(5), 7),
                new Neighbour<int>(new Node<int>(4), 4),               
            });
            edges.Add(4, new List<Neighbour<int>>
            {
                new Neighbour<int>(new Node<int>(5), 2),
                new Neighbour<int>(new Node<int>(6), 8),
            });
            edges.Add(5, new List<Neighbour<int>>
            {
                new Neighbour<int>(new Node<int>(6), 9),                
            });


            // Nodes
            foreach (GuestItineraryPoint point in points)
            {
                Node<GuestItineraryPoint> node = new Node<GuestItineraryPoint>(point);
                nodes.Add(node);
            }

            // Neightbours
            foreach (var edge in edges)
            {
                Node<GuestItineraryPoint> currentNode = nodes.SingleOrDefault(node => node?.Value.Id == edge.Key);
                if (currentNode != null)
                {
                    edge.Value.ForEach(neightbour =>
                    {
                        Node<GuestItineraryPoint> neightbourNode = nodes.SingleOrDefault(node => node?.Value.Id == neightbour.Node.Value);
                        if(neightbourNode != null)
                        {
                            currentNode.AddEdge(neightbourNode, neightbour.Distance);
                        }
                    });
                }
            }
                                                                        

            // Graph
            Graph<GuestItineraryPoint> graph = new Graph<GuestItineraryPoint>(new DijkstraAlgorithm<GuestItineraryPoint>());
            nodes.ForEach(node => graph.AddNode(node));

            return graph;
        }
    }
}
