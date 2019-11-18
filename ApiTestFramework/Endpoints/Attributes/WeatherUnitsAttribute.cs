using ApiTestFramework.Endpoints.Requests.Get.Weather;
using System;

namespace ApiTestFramework.Endpoints.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    class WeatherUnitsAttribute : Attribute
    {
        public WeatherUnits Units { get; set; } = WeatherUnits.metric;
    }
}
