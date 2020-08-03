using System.Collections.Generic;

namespace GraphLibrary
{
    internal class NeighbourComparer<T> : IComparer<Node<T>>
    {
        public int Compare(Node<T> x, Node<T> y)
        {
            if (x.TentativeDistance > y.TentativeDistance)
            {
                return 1;
            }
            if (x.TentativeDistance < y.TentativeDistance)
            {
                return -1;
            }
            return 0;
        }
    }
}
