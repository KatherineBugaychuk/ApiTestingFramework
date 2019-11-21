using ApiTestingFramework.Endpoints.Attributes;

namespace ApiTestingFramework.Endpoints.Requests.Get.Weather
{
    class ByCityCountryRequest : GetRequest
    {
        [CommaSeparatedValues(CountMin = 1, CountMax = 2)]
        public string q { get; set; }

        public ByCityCountryRequest(string cityCountry)
        {
            q = cityCountry;
        }

        public ByCityCountryRequest(string city, string country)
        {
            q = $"{city},{country}";
        }
    }
}
