namespace Homer.api
{
    public interface IPoweredDeviceInfo
    {
        public Homer.model.Outlet Outlet { get; set; }
        
        public double MinConsumption { get; }

        public double MaxConsumption { get; }
    }
}