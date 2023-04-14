public interface ITimeScheduler<T> where T : IComparable<T>
{
    enum ParameterResult
    {
        BELOW_BOUNDS,
        IN_BOUNDS,
        ABOVE_BOUNDS,
        NOT_FOUND
    }

    void addSchedule(Bounds<TimeOnly> timeBounds, Bounds<T> paramBounds);

    void removeSchedule(ScheduleId scheduleId);

    IDictionary<ScheduleId, TimeSchedule<T>> getSchedules();

    ParameterResult checkSchedule(TimeOnly currentTime, T currentParameter);

}