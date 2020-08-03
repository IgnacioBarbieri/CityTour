using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
    public class Node<T>
    {
        private IList<Neighbour<T>> neighbours;

        public IList<Neighbour<T>> Neighbours
        {
            get
            {
                neighbours = neighbours ?? new List<Neighbour<T>>();
                return neighbours;
            }
        }

        public bool Visited
        {
            get; set;
        }

        public T Value
        {
            get; set;
        }

        public int TentativeDistance
        {
            get; set;
        }

        public Node(T value) => Value = value;
  
        public void AddEdge(Node<T> node, int distance)
        {            
            if (!Neighbours.Any(item => item.Node == node))
            {
                Neighbours.Add(new Neighbour<T>(node, distance));
            }

            if (!node.Neighbours.Any( item => item.Node == this))
            {
                node.Neighbours.Add(new Neighbour<T>(this, distance));
            }
        }
      
    }
}
