public record TimeSchedule<T>(Bounds<TimeOnly> timeBounds, Bounds<T> paramBounds) where T : IComparable<T>
{
}