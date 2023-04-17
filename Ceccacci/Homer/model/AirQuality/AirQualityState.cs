namespace Homer.model.AirQuality;

public class AirQualityState : IAirQualityState
{
    private double _co2;
    private double _toxicGasPercentage;
    private double _pm10;
    private double _pm25;

    public AirQualityState(double co2, double pm10, double toxicGasPercentage, double pm25)
    {
        Co2 = co2;
        Pm10 = pm10;
        ToxicGasPercentage = toxicGasPercentage;
        Pm25 = pm25;
    }
    
    public double Co2
    {
        get => _co2;
        set
        {
            RequireGreaterThanZero((value));
            _co2 = value;
        } 
    }

    public double Pm10
    {
        get => _pm10;
        set 
        { 
            RequireGreaterThanZero(value);
            _pm10 = value;
        }
    }


    public double ToxicGasPercentage
    {
        get => _toxicGasPercentage;
        set
        {
            if (value > 100)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "must be smaller or equal than 100");
            }
            RequireGreaterThanZero(value);
            _toxicGasPercentage = value;
        }
    }

    public double Pm25
    {
        get => _pm25;
        set
        {
         RequireGreaterThanZero(value);
         _pm25 = value;
        }
    }

    private static void RequireGreaterThanZero(double value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "must be greater than 0");
        }
    }
}   