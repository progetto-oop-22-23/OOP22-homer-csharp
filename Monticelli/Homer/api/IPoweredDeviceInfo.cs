namespace Homer.api;

public interface IPoweredDeviceInfo
{
    Outlet GetOutlet();

    void SetOutlet(Outlet outlet);
    
    double GetMinConsumption();

    double GetMaxConsumption();
}