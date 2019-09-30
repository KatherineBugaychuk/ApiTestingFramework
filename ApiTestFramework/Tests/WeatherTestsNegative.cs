using ApiTestFramework.Endpoints.Attributes;
using ApiTestFramework.Endpoints.Requests.Get.Weather;
using ApiTestFramework.Endpoints.Responses;
using ApiTestFramework.Validation;
using Newtonsoft.Json;
using NUnit.Framework;

namespace ApiTestFramework.Tests
{
    class WeatherTestsNegative : CommonForWeatherTests
    {
        [Test]
        public void GetWeatherByInvalidCityIdAsSingleId([Values("782,22", "9999999999999999999999999", "invalidstringId", " , ", "-1, -1", "6764,???", "<><\\>")] string invalidId) 
        {
            BySeveralCityIdsRequest request = new BySeveralCityIdsRequest(invalidId);
            CommonResponse expectedResponse = new CommonResponse(400).SetMessage($"{invalidId} is not a city ID");
            SendRequestCheckResponse(request, expectedResponse);
        }

        [Test]  
        public void GetWeatherByInvalidCityIdsAsGroupId([Values("0,0", "-1, -1", "6764,6879")] string invalidId)
        {
            BySeveralCityIdsRequest request = new BySeveralCityIdsRequest(invalidId);
            CommonResponse expectedResponse = new CommonResponse(400).SetMessage($"{invalidId} is not a city ID");
            SendRequestCheckResponse(request, expectedResponse);
        }

        [Test]
        public void GetWeatherByEmptyCityId([Values("", "=?")] string invalidId)
        {
            BySeveralCityIdsRequest request = new BySeveralCityIdsRequest(invalidId);
            CommonResponse expectedResponse = new CommonResponse(400).SetMessage("Nothing to geocode");
            SendRequestCheckResponse(request, expectedResponse);
        }

        [Test]
        public void GetWeatherByMinusOneCityId()
        {
            BySeveralCityIdsRequest request = new BySeveralCityIdsRequest("-1");
            CommonResponse expectedResponse = new CommonResponse(400).SetMessage("Invalid ID");
            SendRequestCheckResponse(request, expectedResponse);
        }

        [Bug("Sequence of characters %c6 is treated like � (replacement character in Unicode)")]
        [Test]
        public void GetWeatherByCityIdsWithInvalidCharacters([Values("??^*%^%c67?", "??^??")] string invalidId) 
        {
            BySeveralCityIdsRequest request = new BySeveralCityIdsRequest(invalidId);
            CommonResponse expectedResponse = new CommonResponse(400).SetMessage($"{invalidId} is not a city ID");
            SendRequestCheckResponse(request, expectedResponse);
        }

        [Test]
        public void GetWeatherViaNonExistingEndpoint() 
        {
            ByCityCountryRequest request = new ByCityCountryRequest("London");
            CommonResponse expectedResponse = new CommonResponse(null, 404).SetMessage("Internal error");
            Response response = NonExistingEndpoint.SendGetRequest(request).Execute().GetResponse(0);
            CommonResponse actualResponse = JsonConvert.DeserializeObject<CommonResponse>(response.ResponseBody);
            Comparator.CompareObjects(actualResponse, expectedResponse);
        }

        [Test]
        public void GetWeatherViaInvalidUrl()
        {
            ByCityCountryRequest request = new ByCityCountryRequest("London");
            CommonResponse expectedResponse = new CommonResponse(null, 401).SetMessage("Invalid API key. Please see http://openweathermap.org/faq#error401 for more info.");
            Response response = WeatherEndpoint.SendGetRequest(request, "https://api.openweathermap.org/data/2.5weatherAPPID=9acb0f4df01ac2645b18fabf8ac4bdc6").Execute().GetResponse(0);
            CommonResponse actualResponse = JsonConvert.DeserializeObject<CommonResponse>(response.ResponseBody);
            Comparator.CompareObjects(actualResponse, expectedResponse);
        }
    }
}
