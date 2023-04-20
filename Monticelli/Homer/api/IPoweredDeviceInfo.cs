namespace Homer.api;

public interface IPoweredDeviceInfo
{
    Outlet getOutlet();

    void setOutlet(Outlet outlet);
    
    double getMinConsumption();

    double getMaxConsumption();
}