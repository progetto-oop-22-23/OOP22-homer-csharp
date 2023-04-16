namespace Homer
{
    /// <summary>
    /// This class encapsulates the concept of comparable objects boundaries.
    /// </summary>
    /// <typeparam name="T">The comparable object type.</typeparam>
    public class Bounds<T> where T : notnull, IComparable<T>
    {
        /// <summary>
        /// Constructs a pair of bounds.
        /// </summary>
        /// <param name="lowerBound">the lower boundary object.</param>
        /// <param name="upperBound">the upper boundary object.</param>
        /// <exception cref="InvertedBoundsException">thrown if the bounds are inverted.</exception>
        public Bounds(T lowerBound, T upperBound)
        {
            if (lowerBound.CompareTo(upperBound) > 0)
            {
                throw new InvertedBoundsException();
            }
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        /// <summary>
        /// The lower boundary object.
        /// </summary>
        public T LowerBound { get; }

        /// <summary>
        /// The upper boundary object.
        /// </summary>
        public T UpperBound { get; }
    }
}
