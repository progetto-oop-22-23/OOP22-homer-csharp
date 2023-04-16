using System.Runtime.CompilerServices;
using Xunit;

namespace Homer.Tests;

public class TemperatureTest
{
    private readonly int significantFigures = 3;
    [Fact]
    public void TestCelsius()
    {
        var temperature = TemperatureFactory.fromCelsius(0);
        Assert.Equal(0, temperature.Celsius, significantFigures);
        Assert.Equal(273.15d, temperature.Kelvin, significantFigures);
        Assert.Equal(32d, temperature.Fahrenheit, significantFigures);
    }
    
    [Fact]
    public void TestFahrenheit()
    {
        
        var temperature = TemperatureFactory.FromFahrenheit(53);
        Assert.Equal(11.667, temperature.Celsius, significantFigures);
        Assert.Equal(53, temperature.Fahrenheit, significantFigures);
        Assert.Equal(284.817, temperature.Kelvin, significantFigures);
    }

    [Fact]
    public void TestKelvin()
    {
        var temperature = TemperatureFactory.fromKelvin(20);
        Assert.Equal(-253.15, temperature.Celsius, significantFigures);
        Assert.Equal(20, temperature.Kelvin, significantFigures);
        Assert.Equal(-423.6699, temperature.Fahrenheit, significantFigures);
    }
}