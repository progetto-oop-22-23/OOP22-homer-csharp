namespace Homer
{
    /// <summary>
    /// Implementation of a <see cref="ITimeScheduler{T}"/>.
    /// </summary>
    /// <typeparam name="T">the type of data to target for the schedule.</typeparam>
    public sealed class TimeScheduler<T> : ITimeScheduler<T> where T : IComparable<T>
    {
        private IDictionary<ScheduleId, TimeSchedule<T>> Schedules { get; } = new Dictionary<ScheduleId, TimeSchedule<T>>();

        public void AddSchedule(Bounds<TimeOnly> timeBounds, Bounds<T> paramBounds)
        {
            if (!IsOverlapsing(timeBounds))
            {
                Schedules.Add(new ScheduleId(), new TimeSchedule<T>(timeBounds, paramBounds));
            }
            else
            {
                throw new ArgumentException("selected time range is colliding with another existing schedule!");
            }
        }

        public void RemoveSchedule(ScheduleId scheduleId) => Schedules.Remove(scheduleId);

        public IDictionary<ScheduleId, TimeSchedule<T>> GetSchedules() => new Dictionary<ScheduleId, TimeSchedule<T>>(Schedules);

        public ITimeScheduler<T>.ParameterResult CheckSchedule(TimeOnly currentTime, T currentParameter)
        {
            var targetBounds = Schedules.Values
                    .Where(s => TimeScheduler<T>.IsTimeWithinBounds(currentTime, s.TimeBounds))
                    .Select(s => s.ParamBounds)
                    .First();
            if (targetBounds is null)
            {
                return ITimeScheduler<T>.ParameterResult.NOT_FOUND;
            }
            else if (currentParameter.CompareTo(targetBounds.LowerBound) < 0)
            {
                return ITimeScheduler<T>.ParameterResult.BELOW_BOUNDS;
            }
            else if (currentParameter.CompareTo(targetBounds.UpperBound) > 0)
            {
                return ITimeScheduler<T>.ParameterResult.ABOVE_BOUNDS;
            }
            else
            {
                return ITimeScheduler<T>.ParameterResult.IN_BOUNDS;
            }
        }

        private bool IsOverlapsing(Bounds<TimeOnly> timeBounds)
        {
            var newTimeStart = timeBounds.LowerBound;
            var newTimeEnd = timeBounds.UpperBound;
            return Schedules.Values
                .Select(ts => ts.TimeBounds)
                .Where(tb => TimeScheduler<T>.AreBoundsWithinBounds(timeBounds, tb) || TimeScheduler<T>.AreBoundsWithinBounds(tb, timeBounds)
                            || TimeScheduler<T>.IsTimeWithinBounds(newTimeStart, tb) || TimeScheduler<T>.IsTimeWithinBounds(newTimeEnd, tb))
                .Any();
        }

        // checks if boundsA are within or coincident with boundsB
        private static bool AreBoundsWithinBounds(Bounds<TimeOnly> boundsA, Bounds<TimeOnly> boundsB)
        {
            return boundsA.LowerBound.CompareTo(boundsB.LowerBound) >= 0
                && boundsA.UpperBound.CompareTo(boundsB.UpperBound) <= 0;
        }

        private static bool IsTimeWithinBounds(TimeOnly time, Bounds<TimeOnly> timeBounds)
        {
            return time.CompareTo(timeBounds.LowerBound) >= 0
                && time.CompareTo(timeBounds.UpperBound) <= 0;
        }
    }
}
