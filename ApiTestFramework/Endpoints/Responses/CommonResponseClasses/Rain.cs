using Newtonsoft.Json;

namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Rain
    {
        [JsonProperty(PropertyName = "3h")]
        public double? threeh { get; set; }

        public override string ToString()
        {
            return "{" +
                    "\"3h\":" + threeh +
                    "}";
        }
    }
}
