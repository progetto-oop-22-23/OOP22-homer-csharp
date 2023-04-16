namespace Homer.Temperature;
/// <summary>
/// Factory for ITemperature objects.
/// </summary>
public static class TemperatureFactory
{
    public static ITemperature FromCelsius(double temperature) =>
        FromKelvin(temperature + ITemperature.DeltaKelvinCelsius);

    public static ITemperature FromKelvin(double temperature) => new KelvinTemperature(temperature);

    public static ITemperature FromFahrenheit(double temperature) =>
        FromKelvin((temperature + ITemperature.DeltaFahrenheitKelvin) * ITemperature.FiveNines);
}
