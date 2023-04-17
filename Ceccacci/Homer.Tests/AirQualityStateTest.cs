using System;
using Homer.model.AirQuality;
using Xunit;

namespace Homer.Tests;

public class AirQualityStateTest
{
    [Fact]
    public void TestRequireGreaterOrEqualThanZeroConstructor()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new AirQualityState(-1, 0, 0, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new AirQualityState(0, -1, 0, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new AirQualityState(-0, 0, -1, 0));
        Assert.Throws<ArgumentOutOfRangeException>(() => new AirQualityState(0, -1, 0, -1));
    }
    
    [Fact]
    public void TestRequireToxicGasPercentageSmallerOrEqualThanOneHundred()
    {
        var airQualityState = new AirQualityState(0, 0, 0, 0);
        Assert.Throws<ArgumentOutOfRangeException>(() => airQualityState.ToxicGasPercentage = 101.5);
    }
    
}