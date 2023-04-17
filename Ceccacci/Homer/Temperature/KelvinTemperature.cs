namespace Homer.Temperature;

/// <summary>
/// Temperature that uses kelvin as a base value.
/// </summary>
public class KelvinTemperature : ITemperature
{
    public KelvinTemperature(double kelvin)
    {
        Kelvin = kelvin;
    }
    public double Kelvin { get; }
    public double Fahrenheit => Celsius / ITemperature.FiveNines + ITemperature.DeltaKelvinFahrenheit;
    public double Celsius => Kelvin - ITemperature.DeltaKelvinCelsius;
    
    public int CompareTo(ITemperature? other)
    {
        return other == null ? 1 : this.Kelvin.CompareTo(other.Kelvin);
    }
}