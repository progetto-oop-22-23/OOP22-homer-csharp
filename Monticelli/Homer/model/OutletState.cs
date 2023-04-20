namespace homer.model
{
    public class OutletState : IOutletState
    {
        private double _minConsumption;
        private double _maxConsumption;
        private double _consumption;

        public OutletState(double minConsumption, double maxConsumption, double consumption)
        {
            _minConsumption = minConsumption;
            _maxConsumption = maxConsumption;
            _consumption = consumption;
        }

        public double MinConsumption
        {
            get => _minConsumption;

            set => _minConsumption = value;
        }

        public double MaxConsumption
        {
            get => _maxConsumption;

            set => _maxConsumption = value;
        }

        public double Consumption
        {
            get => _consumption;

            set => _consumption = value;
        }
    }
}