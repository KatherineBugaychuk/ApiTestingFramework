namespace ApiTestFramework.Endpoints.Requests.Get.Weather
{
    class ByZipCodeRequest : GetRequest
    {
        public string zip { get; set; }

        public ByZipCodeRequest(string zip)
        {
            this.zip = zip;
        }
    }
}
