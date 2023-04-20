namespace Homer.api
{
    public class PoweredDeviceInfo : IPoweredDeviceInfo
    {
        private readonly double _minConsumption;
        private readonly double _maxConsumption;
        private Outlet _outlet;

        public PoweredDeviceInfo(double minConsumption, double maxConsumption, Outlet outlet) 
        {
            _minConsumption = minConsumption;
            _maxConsumption = maxConsumption;
            _outlet = outlet;
        }

        public Outlet GetOutlet() => _outlet;

        public void SetOutlet(Outlet outlet) => _outlet = outlet;

        public double GetMinConsumption() => _minConsumption;

        public double GetMaxConsumption() => _maxConsumption;

        public override bool Equals(object obj) {
            if (this == obj) 
            {
                return true;
            }

            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var that = (PoweredDeviceInfoImpl)obj;

            if (that._minConsumption.CompareTo(_minConsumption) != 0)
            {
                return false;
            }

            if(that._maxConsumption.CompareTo(_maxConsumption) != 0)
            {
                return false;
            }

            return _outlet.Equals(that._outlet);
        }

        public override int GetHashCode() {
            return GetOutlet().GetHashCode();
        }
    }
}