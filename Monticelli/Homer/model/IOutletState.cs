namespace Homer.model
{
    public interface IOutletState
    {
        public double MinConsumption { get; set; }
        public double MaxConsumption { get; set; }
        public double Consumption { get; set; }
    }
}