public record ScheduleId(Guid scheduleId)
{
    public ScheduleId() : this(Guid.NewGuid()) { }
}