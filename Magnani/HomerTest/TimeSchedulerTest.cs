using Homer;

namespace HomerTest
{
    [TestClass]
    public class TimeSchedulerTest
    {
        // Mock temperature class
        private class Temperature : IComparable<Temperature>
        {
            public Temperature(double celsius) => Celsius = celsius;
            public double Celsius { get; }
            public int CompareTo(Temperature? other) => Celsius.CompareTo(other?.Celsius);
        }
        // Mock temperature factory class
        private class TemperatureFactory
        {
            public static Temperature FromCelsius(double celsius) => new(celsius);
        }

        private static readonly Bounds<TimeOnly> TIME_RANGE = new(new TimeOnly(9, 0), new TimeOnly(12, 0));
        private static readonly Bounds<Temperature> TEMP_RANGE = new(TemperatureFactory.FromCelsius(19), TemperatureFactory.FromCelsius(22));
        private static readonly TimeOnly TIME_EARLY = new(0, 0);
        private static readonly TimeOnly TIME_IN_RANGE = new(10, 0);
        private static readonly TimeOnly TIME_LATER = new(23, 0);
        private static readonly Temperature TEMP_BELOW = TemperatureFactory.FromCelsius(0);
        private static readonly Temperature TEMP_IN_RANGE = TemperatureFactory.FromCelsius(20);
        private static readonly Temperature TEMP_ABOVE = TemperatureFactory.FromCelsius(30);

        private TimeScheduler<Temperature>? _scheduler;

        [TestInitialize]
        public void Start()
        {
            _scheduler = new TimeScheduler<Temperature>();
        }

        [TestMethod]
        public void TestAddSchedule()
        {
            InitSchedules();

            TimeSchedule<Temperature>? schedule = _scheduler?.GetSchedules().Values.First();
            Assert.AreEqual(TIME_RANGE, schedule?.TimeBounds);
            Assert.AreEqual(TEMP_RANGE, schedule?.ParamBounds);
        }

        [TestMethod]
        public void TestOverlapping()
        {
            InitSchedules();

            CheckOverlapping(TIME_RANGE);
            CheckOverlapping(new Bounds<TimeOnly>(TIME_EARLY, TIME_IN_RANGE));
            CheckOverlapping(new Bounds<TimeOnly>(TIME_IN_RANGE, TIME_LATER));
            CheckOverlapping(new Bounds<TimeOnly>(TIME_IN_RANGE, TIME_IN_RANGE));
        }

        [TestMethod]
        public void TestRemoveSchedule()
        {
            InitSchedules();

            ScheduleId? id = _scheduler?.GetSchedules().Keys.First();
            Assert.IsNotNull(id);
            _scheduler?.RemoveSchedule(id);
            Assert.AreEqual(0, _scheduler?.GetSchedules().Count);
        }

        [TestMethod]
        public void TestCheckSchedule()
        {
            InitSchedules();

            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.NOT_FOUND, _scheduler?.CheckSchedule(TIME_EARLY, TEMP_IN_RANGE));
            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.NOT_FOUND, _scheduler?.CheckSchedule(TIME_LATER, TEMP_IN_RANGE));

            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.BELOW_BOUNDS, _scheduler?.CheckSchedule(TIME_IN_RANGE, TEMP_BELOW));
            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.IN_BOUNDS, _scheduler?.CheckSchedule(TIME_IN_RANGE, TEMP_IN_RANGE));
            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.ABOVE_BOUNDS, _scheduler?.CheckSchedule(TIME_IN_RANGE, TEMP_ABOVE));
        }

        private void InitSchedules()
        {
            Assert.AreEqual(0, _scheduler?.GetSchedules().Count);
            _scheduler?.AddSchedule(TIME_RANGE, TEMP_RANGE);
            Assert.AreEqual(1, _scheduler?.GetSchedules().Count);
        }

        private void CheckOverlapping(Bounds<TimeOnly> newTimeRange)
        {
            int? sizeBefore = _scheduler?.GetSchedules().Count;
            Assert.ThrowsException<ArgumentException>(() => _scheduler?.AddSchedule(newTimeRange, TEMP_RANGE));
            Assert.AreEqual(sizeBefore, _scheduler?.GetSchedules().Count);
        }
    }
}
