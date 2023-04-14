namespace Homer;

public interface ITemperature: IComparable<ITemperature>
{
    const double DeltaKelvinCelsius = 273.15;
    const double DeltaFahrenheitCelsius = 459.67;
    const double FiveNines = 5 / 9f;
    const double DeltaKelvinFahrenheit = 32;
    double Kelvin { get; }
    double Fahrenheit { get; }
    double Celsius { get;}
}