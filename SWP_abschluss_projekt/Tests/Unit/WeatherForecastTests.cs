using SWP_abschluss_projekt;
using NUnit.Framework;

namespace SWP_abschluss_projekt.Tests.Unit;

public class WeatherForecastTests
{
    [Test]
    public void TemperatureF_Computes_From_Celsius()
    {
        var forecast = new WeatherForecast { TemperatureC = 0 };
        Assert.AreEqual(32, forecast.TemperatureF);

        forecast.TemperatureC = 100;
        Assert.AreEqual(212, forecast.TemperatureF);
    }
}
