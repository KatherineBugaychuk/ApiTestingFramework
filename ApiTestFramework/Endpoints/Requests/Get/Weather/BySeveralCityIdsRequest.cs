namespace ApiTestFramework.Endpoints.Requests.Get.Weather
{
    class BySeveralCityIdsRequest : GetRequest
    {
        public string id { get; set; }

        public BySeveralCityIdsRequest(string id)
        {
            this.id = id;
        }
    }
}
