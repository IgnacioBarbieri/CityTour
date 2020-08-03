using System.Collections.Generic;

namespace GraphLibrary
{
    public interface IPathFindingAlgorithm<T>
    {
        IEnumerable<Node<T>> FindShortestPath(IEnumerable<Node<T>> nodes, Node<T> start, Node<T> finish);
    }
}
