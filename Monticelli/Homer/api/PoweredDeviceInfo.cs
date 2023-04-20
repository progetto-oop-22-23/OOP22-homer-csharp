namespace Homer.api
{
    public class PoweredDeviceInfo : IPoweredDeviceInfo
    {
        private readonly double _minConsumption;
        private readonly double _maxConsumption;
        private Homer.model.Outlet _outlet;

        public PoweredDeviceInfo(double minConsumption, double maxConsumption, Homer.model.Outlet outlet) 
        {
            _minConsumption = minConsumption;
            _maxConsumption = maxConsumption;
            _outlet = outlet;
        }

        public Homer.model.Outlet Outlet
        {
            get => _outlet;

            set => _outlet = value;
        }

        public double MinConsumption
        {
            get => _minConsumption;
        }

        public double MaxConsumption
        {
            get => _maxConsumption;
        }

        public override bool Equals(object obj) {
            if (this == obj) 
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var that = (PoweredDeviceInfo) obj;

            if (that.MinConsumption.CompareTo(_minConsumption) != 0)
            {
                return false;
            }

            if(that.MaxConsumption.CompareTo(_maxConsumption) != 0)
            {
                return false;
            }

            return _outlet.Equals(that.Outlet);
        }

        public override int GetHashCode() {
            return Outlet.GetHashCode();
        }
    }
}