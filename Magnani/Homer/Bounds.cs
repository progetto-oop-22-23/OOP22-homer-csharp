public class Bounds<T> where T : notnull, IComparable<T>
{
    public T lowerBound { get; }
    public T upperBound { get; }

    public Bounds(T lowerBound, T upperBound)
    {
        this.lowerBound = lowerBound;
        this.upperBound = upperBound;
    }
}