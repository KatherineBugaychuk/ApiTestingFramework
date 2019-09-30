namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Main
    {
        public double? temp { get; set; }
        public int? humidity { get; set; }
        public int? pressure { get; set; }
        public double? temp_min { get; set; }
        public double? temp_max { get; set; }

        public override string ToString()
        {
            return "{" +
                    "\"temp\":" + temp +
                    ",\"humidity\":" + humidity +
                    ",\"pressure\":" + pressure +
                    ",\"temp_min\":" + temp_min +
                    ",\"temp_max\":" + temp_max +
                    "}";
        }
    }
}
