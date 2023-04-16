namespace Homer
{
    /// <summary>
    /// This interface models a component which assures that certain constraints on
    /// certain parameters are met in a certain interval of time.
    /// </summary>
    /// <typeparam name="T">The parameter that should meet the constraints.</typeparam>
    public interface ITimeScheduler<T> where T : IComparable<T>
    {
        /// <summary>
        /// Indicates where the current parameter stands when checked against the
        /// schedule, or whether no applicable schedule was found.
        /// </summary>
        enum ParameterResult
        {
            /// <summary>
            /// Parameter is below the target bounds.
            /// </summary>
            BELOW_BOUNDS,
            /// <summary>
            /// Parameter is within the target bounds.
            /// </summary>
            IN_BOUNDS,
            /// <summary>
            /// Parameter is above the target bounds.
            /// </summary>
            ABOVE_BOUNDS,
            /// <summary>
            /// No applicable schedule was found.
            /// </summary>
            NOT_FOUND
        }

        /// <summary>
        /// Adds a new schedule.
        /// </summary>
        /// <param name="timeBounds">the time bounds for the schedule.</param>
        /// <param name="paramBounds">the target parameter bounds for the schedule.</param>
        void AddSchedule(Bounds<TimeOnly> timeBounds, Bounds<T> paramBounds);

        /// <summary>
        /// Removes a schedule.
        /// </summary>
        /// <param name="scheduleId">the id of the schedule to remove.</param>
        void RemoveSchedule(ScheduleId scheduleId);

        /// <summary>
        /// Returns the added schedules.
        /// </summary>
        /// <returns>the added schedules.</returns>
        IDictionary<ScheduleId, TimeSchedule<T>> GetSchedules();

        /// <summary>
        /// Checks if the constraints are met, and returns whether the parameter is
        /// below/above/within bounds or if no schedule exists for the current time.
        /// </summary>
        /// <param name="currentTime">The current 24h clock time.</param>
        /// <param name="currentParameter">The current parameter to check against the constraints.</param>
        /// <returns>the state of the <paramref name="currentParameter"/> with regards to the schedules.</returns>
        ParameterResult CheckSchedule(TimeOnly currentTime, T currentParameter);

    }
}