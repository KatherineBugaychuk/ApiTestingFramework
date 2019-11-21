using ApiTestingFramework.Endpoints.Requests.Get.Weather;
using System;

namespace ApiTestingFramework.Endpoints.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class WeatherUnitsAttribute : Attribute
    {
        public WeatherUnits Units { get; set; } = WeatherUnits.metric;
    }
}
