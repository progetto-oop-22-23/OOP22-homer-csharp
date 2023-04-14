namespace Homer;

public class KelvinTemperature : ITemperature
{
    public KelvinTemperature(double kelvin)
    {
        Kelvin = kelvin;
    }
    public double Kelvin { get;}
    public double Fahrenheit => Celsius / ITemperature.FiveNines + ITemperature.DeltaKelvinFahrenheit;
    public double Celsius => Kelvin - ITemperature.DeltaKelvinCelsius;
    
    public int CompareTo(ITemperature? other)
    {
        if (other == null) return 1;
        return this.Kelvin.CompareTo(other.Kelvin);
    }
}