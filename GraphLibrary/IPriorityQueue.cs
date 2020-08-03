namespace GraphLibrary
{
    public interface IPriorityQueue<T>
    {
        int Count { get; }

        bool Contains(T item);
        T Pop();
        void Push(T item);
    }
}