using System.Runtime.CompilerServices;
using Homer.Temperature;
using Xunit;

namespace Homer.Tests;

public class TemperatureTest
{
    private const int SignificantFigures = 3;

    [Fact]
    public void TestCelsius()
    {
        var temperature = TemperatureFactory.FromCelsius(0);
        Assert.Equal(0, temperature.Celsius, SignificantFigures);
        Assert.Equal(273.15d, temperature.Kelvin, SignificantFigures);
        Assert.Equal(32d, temperature.Fahrenheit, SignificantFigures);
    }
    
    [Fact]
    public void TestFahrenheit()
    {
        
        var temperature = TemperatureFactory.FromFahrenheit(53);
        Assert.Equal(11.667, temperature.Celsius, SignificantFigures);
        Assert.Equal(53, temperature.Fahrenheit, SignificantFigures);
        Assert.Equal(284.817, temperature.Kelvin, SignificantFigures);
    }

    [Fact]
    public void TestKelvin()
    {
        var temperature = TemperatureFactory.FromKelvin(20);
        Assert.Equal(-253.15, temperature.Celsius, SignificantFigures);
        Assert.Equal(20, temperature.Kelvin, SignificantFigures);
        Assert.Equal(-423.6699, temperature.Fahrenheit, SignificantFigures);
    }
}