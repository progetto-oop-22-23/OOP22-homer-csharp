namespace Homer.model
{
    public class Outlet : IOutlet
    {
        private OutletState _state;

        public Outlet(OutletState state)
        {
            _state = state;
        }

        public Outlet(Outlet outlet)
        {
            _state = outlet.State;
        }

        public OutletState State
        {
            get => _state;

            set => _state = value;
        }

        public void UpdateTick(System.TimeSpan timeSpan)
        {
            double randomIncrement = System.Math.Sin(timeSpan.Seconds);
            this.State.Consumption += randomIncrement;
        }
    }
}