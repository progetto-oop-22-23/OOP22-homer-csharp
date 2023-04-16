namespace Homer
{
    /// <summary>
    /// Represents a constraint on a certain parameter that should
    /// be met in a certain time interval.
    /// </summary>
    /// <typeparam name="T">The parameter that should meet the constraint.</typeparam>
    /// <param name="TimeBounds">the time interval.</param>
    /// <param name="ParamBounds">the target parameter interval.</param>
    public record TimeSchedule<T>(Bounds<TimeOnly> TimeBounds, Bounds<T> ParamBounds) where T : IComparable<T>
    {
    }
}