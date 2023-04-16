namespace Homer.Temperature;

/// <summary>
/// 
/// </summary>
public interface ITemperature: IComparable<ITemperature>
{
    
    const double DeltaKelvinCelsius = 273.15;
    const double DeltaFahrenheitKelvin = 459.67;
    const double FiveNines = 5 / 9f;
    const double DeltaKelvinFahrenheit = 32;
    
    /// <summary>
    /// Returns the temperature in kelvin.
    /// <returns> The temperature in kelvin.</returns>
    /// </summary>
    double Kelvin { get; }
    /// <summary>
    /// Returns the temperature in celsius.
    /// <returns>The temperature in celsius</returns>
    /// </summary>
    double Fahrenheit { get; }
    /// <summary>
    /// Returns the temperature in celsius.
    /// <returns>The temperature in celsius</returns>
    /// </summary>
    double Celsius { get;}
}