namespace Homer.model
{
    public interface IOutlet
    {
        public OutletState State { get; set; }

        void UpdateTick(System.TimeSpan timeSpan);
    }
}