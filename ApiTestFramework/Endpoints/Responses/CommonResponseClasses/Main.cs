using ApiTestFramework.Endpoints.Attributes;

namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Main
    {
        [Mandatory]
        public double? temp { get; set; }
        public int? humidity { get; set; }
        public int? pressure { get; set; }
        public double? temp_min { get; set; }
        public double? temp_max { get; set; }
    }
}
