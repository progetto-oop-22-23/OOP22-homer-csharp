namespace Homer
{
    /// <summary>
    /// Represents an unique id for a schedule.
    /// </summary>
    /// <param name="Id">the schedule id.</param>
    public record ScheduleId(Guid Id)
    {
        /// <summary>
        /// Creates a new <see cref="ScheduleId"/> with a random <see cref="Guid"/>.
        /// </summary>
        public ScheduleId() : this(Guid.NewGuid()) { }
    }
}
