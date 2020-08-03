using System;
using System.Collections.Generic;

namespace GraphLibrary
{
    public class Graph<T>
    {
        private readonly IPathFindingAlgorithm<T> pathFindingAlgorithm;
        private List<Node<T>> nodes;

        public IEnumerable<Node<T>> Nodes
        {
            get { return nodes; }
        }

        public Graph(IPathFindingAlgorithm<T> pathFindingAlgorithm)
        {
            if (pathFindingAlgorithm == null)
            {
                throw new ArgumentNullException(nameof(pathFindingAlgorithm));
            }

            nodes = new List<Node<T>>();
            this.pathFindingAlgorithm = pathFindingAlgorithm;
        }

        public void AddNode(Node<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException(nameof(node)); 
            }

            if (!nodes.Contains(node))
            {
                nodes.Add(node); 
            }                
        }

        public IEnumerable<Node<T>> FindShortestPath(Node<T> start, Node<T> finish) => pathFindingAlgorithm.FindShortestPath(Nodes, start, finish);
    }
}
