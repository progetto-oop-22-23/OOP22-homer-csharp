namespace Homer.model.AirQuality;

/// <summary>
/// Models the air quality information we want to return to users.
/// Since the units of measurement are unlikely to change, they are defined as doubles.
/// </summary>
public interface IAirQualityState
{
    public double Co2 { get; set; }
    public double Pm10 { get; set; }
    public double ToxicGasPercentage { get; set; }
    public double Pm25{ get; set; }
}