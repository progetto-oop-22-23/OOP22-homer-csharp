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

        private static readonly Bounds<TimeOnly> s_timeRange = new(new TimeOnly(9, 0), new TimeOnly(12, 0));
        private static readonly Bounds<Temperature> s_tempRange = new(TemperatureFactory.FromCelsius(19), TemperatureFactory.FromCelsius(22));
        private static readonly TimeOnly s_timeEarly = new(0, 0);
        private static readonly TimeOnly s_timeInRange = new(10, 0);
        private static readonly TimeOnly s_timeLater = new(23, 0);
        private static readonly Temperature s_tempBelow = TemperatureFactory.FromCelsius(0);
        private static readonly Temperature s_tempInRange = TemperatureFactory.FromCelsius(20);
        private static readonly Temperature s_tempAbove = TemperatureFactory.FromCelsius(30);

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
            Assert.AreEqual(s_timeRange, schedule?.TimeBounds);
            Assert.AreEqual(s_tempRange, schedule?.ParamBounds);
        }

        [TestMethod]
        public void TestOverlapping()
        {
            InitSchedules();

            CheckOverlapping(s_timeRange);
            CheckOverlapping(new Bounds<TimeOnly>(s_timeEarly, s_timeInRange));
            CheckOverlapping(new Bounds<TimeOnly>(s_timeInRange, s_timeLater));
            CheckOverlapping(new Bounds<TimeOnly>(s_timeInRange, s_timeInRange));
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

            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.NotFound, _scheduler?.CheckSchedule(s_timeEarly, s_tempInRange));
            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.NotFound, _scheduler?.CheckSchedule(s_timeLater, s_tempInRange));

            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.BelowBounds, _scheduler?.CheckSchedule(s_timeInRange, s_tempBelow));
            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.InBounds, _scheduler?.CheckSchedule(s_timeInRange, s_tempInRange));
            Assert.AreEqual(ITimeScheduler<Temperature>.ParameterResult.AboveBounds, _scheduler?.CheckSchedule(s_timeInRange, s_tempAbove));
        }

        private void InitSchedules()
        {
            Assert.AreEqual(0, _scheduler?.GetSchedules().Count);
            _scheduler?.AddSchedule(s_timeRange, s_tempRange);
            Assert.AreEqual(1, _scheduler?.GetSchedules().Count);
        }

        private void CheckOverlapping(Bounds<TimeOnly> newTimeRange)
        {
            int? sizeBefore = _scheduler?.GetSchedules().Count;
            Assert.ThrowsException<ArgumentException>(() => _scheduler?.AddSchedule(newTimeRange, s_tempRange));
            Assert.AreEqual(sizeBefore, _scheduler?.GetSchedules().Count);
        }
    }
}
