using ApiTestingFramework.Endpoints.Requests.Get.Weather;
using ApiTestingFramework.Endpoints.Responses;
using NUnit.Framework;

namespace ApiTestingFramework.Tests
{
    [TestFixture]
    class WeatherTestsPositive : CommonForWeatherTests
    {
        [Test]
        public void GetWeatherByCity()
        {
            string city = "London";
            ByCityCountryRequest request = new ByCityCountryRequest(city);
            CommonResponse expectedResponse = new CommonResponse(city, 200);
            SendRequestCheckResponseWithValidation(request, expectedResponse);
        }

        [Test]
        public void GetWeatherByCityAndCountry()
        {
            string city = "Kyiv";
            string country = "UA";
            ByCityCountryRequest request = new ByCityCountryRequest(city, country);
            CommonResponse expectedResponse = new CommonResponse(city, 200, country);
            SendRequestCheckResponseWithValidation(request, expectedResponse);
        }

        [Test]
        public void GetWeatherByCoordinates()
        {
            ByCoordinatesRequest request = new ByCoordinatesRequest(35, 139);
            CommonResponse expectedResponse = new CommonResponse("Shuzenji", 200, "JP");
            SendRequestCheckResponseWithValidation(request, expectedResponse);
        }
    }
}
