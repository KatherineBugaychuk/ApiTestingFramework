using Newtonsoft.Json;

namespace ApiTestingFramework.Endpoints.Responses.CommonResponseClasses
{
    class Rain
    {
        [JsonProperty(PropertyName = "3h")]
        public double? threeh { get; set; }
    }
}
