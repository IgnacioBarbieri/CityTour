using System.Collections.Generic;
using System.Linq;

namespace GraphLibrary
{
    public class DijkstraAlgorithm<T> : IPathFindingAlgorithm<T>
    {        
        private IPriorityQueue<Node<T>> unvistedNodes;
                
        public IEnumerable<Node<T>> FindShortestPath(IEnumerable<Node<T>> nodes, Node<T> start, Node<T> finish)
        {
            List<Node<T>> graph = nodes.ToList(); 

            InitializeGraph(graph);
            start.TentativeDistance = 0;

            var current = start;

            while (true)
            {
                foreach (var neighbour in current.Neighbours.Where(x => !x.Node.Visited))
                {
                    var newTentativeDistance = current.TentativeDistance + neighbour.Distance;
                    if (newTentativeDistance < neighbour.Node.TentativeDistance)
                    {
                        neighbour.Node.TentativeDistance = newTentativeDistance;
                    }
                }

                current.Visited = true;

                var next = unvistedNodes.Pop();
                if (next == null || next.TentativeDistance == int.MaxValue)
                {
                    if (finish.TentativeDistance == int.MaxValue)
                    {
                        return new List<Node<T>>();//no path
                    }
                    finish.Visited = true;
                    break;
                }

                var smallest = next;
                current = smallest;
            }

            return DeterminePathFromWeightedGraph(start, finish);
        }

        private void InitializeGraph(List<Node<T>> graph)
        {
            unvistedNodes = new PriorityQueue<Node<T>>(new NeighbourComparer<T>());
            graph.ForEach(x =>
            {
                x.Visited = false;
                x.TentativeDistance = int.MaxValue;
                unvistedNodes.Push(x);
            });
        }

        private List<Node<T>> DeterminePathFromWeightedGraph(Node<T> start, Node<T> finish)
        {
            var current = finish;
            var path = new List<Node<T>> { current };
            var currentTentativeDistance = finish.TentativeDistance;

            while (true)
            {
                if (current == start)
                {
                    break;
                }

                foreach (var neighbour in current.Neighbours.Where(x => x.Node.Visited))
                {
                    if (currentTentativeDistance - neighbour.Distance == neighbour.Node.TentativeDistance)
                    {
                        current = neighbour.Node;
                        path.Add(current);
                        currentTentativeDistance -= neighbour.Distance;
                        break;
                    }
                }
            }

            path.Reverse();
            return path;
        }       
    }
}
