namespace Homer;

public static class TemperatureFactory
{
    public static ITemperature fromCelsius(double temperature) =>
        fromKelvin(temperature + ITemperature.DeltaKelvinCelsius);

    public static ITemperature fromKelvin(double temperature) => new KelvinTemperature(temperature);

    public static ITemperature FromFahrenheit(double temperature) =>
        fromKelvin((temperature + ITemperature.DeltaFahrenheitKelvin) * ITemperature.FiveNines);
}
