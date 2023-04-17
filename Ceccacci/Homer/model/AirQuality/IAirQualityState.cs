namespace Homer.model.AirQuality;

public interface IAirQualityState
{
    public double Co2 { get; set; }
    public double Pm10 { get; set; }
    public double ToxicGasPercentage { get; set; }
    public double Pm25{ get; set; }
}