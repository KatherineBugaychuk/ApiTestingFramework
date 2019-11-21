using ApiTestingFramework.Endpoints.Attributes;

namespace ApiTestingFramework.Endpoints.Requests.Get.Weather
{
    class ByCityIdRequest : GetRequest
    {
        [CommaSeparatedValues(CountMin = 1, CountMax = 2)]
        public int id { get; set; }

        public ByCityIdRequest(int id)
        {
            this.id = id;
        }
    }
}
