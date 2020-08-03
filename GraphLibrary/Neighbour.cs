namespace GraphLibrary
{
    public class Neighbour<T>
    {
        public int Distance
        {
            get;
            set;
        }

        public Node<T> Node
        {
            get;
            set;
        }

        public Neighbour(Node<T> node, int distance)
        {
            Node = node;
            Distance = distance;
        }
    }
}
