using Newtonsoft.Json;

namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Rain
    {
        [JsonProperty(PropertyName = "3h")]
        public double? threeh { get; set; }

        public string GetString()
        {
            return "{" +
                    "\"3h\":" + threeh +
                    "}";
        }
    }
}
