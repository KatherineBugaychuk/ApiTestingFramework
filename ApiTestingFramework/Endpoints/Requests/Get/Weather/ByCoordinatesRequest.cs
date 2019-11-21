namespace ApiTestingFramework.Endpoints.Requests.Get.Weather
{
    class ByCoordinatesRequest : GetRequest
    {
        public int lat { get; set; }
        public int lon { get; set; }

        public ByCoordinatesRequest(int lat, int lon)
        {
            this.lat = lat;
            this.lon = lon;
        }
    }
}
