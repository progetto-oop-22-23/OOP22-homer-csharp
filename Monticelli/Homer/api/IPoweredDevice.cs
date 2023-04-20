namespace Homer.api;

public interface IPoweredDevice
{
    double getInstantConsumption();

    void setInstantConsumption(double instantConsumption);

    void plug(Outlet outlet);

    PoweredDeviceInfo getPowerInfo();
}