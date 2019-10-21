namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Coord
    {
        public double? lon { get; set; }
        public double? lat { get; set; }

        public string GetString()
        {
            return "{" +
                    "\"lon\":" + lon +
                    ",\"lat\":" + lat +
                    "}";
        }
    }
}
