namespace Homer.api
{
    public interface IPoweredDevice
    {
        public double InstantConsumption { get; set; }

        void Plug(Homer.model.Outlet outlet);

        public Homer.api.PoweredDeviceInfo PoweredDeviceInfo { get; }
    }
}