namespace Homer.model;

public class Outlet : IOutlet
{

    private OutletState _state;

    public Outlet(readonly OutletState state)
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

    public void UpdateTick(TimeSpan timeSpan)
    {
        double randomIncrement = Math.sin(timeSpan.Seconds);
        this.State += randomIncrement;
    }

}