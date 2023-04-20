namespace Homer.api
{
    public interface IPoweredDevice
    {
        double GetInstantConsumption();

        void SetInstantConsumption(double instantConsumption);

        void Plug(Outlet outlet);

        PoweredDeviceInfo GetPowerInfo();
    }
}