namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Coord
    {
        public double? lon { get; set; }
        public double? lat { get; set; }

        public override string ToString()
        {
            return "{" +
                    "\"lon\":" + lon +
                    ",\"lat\":" + lat +
                    "}";
        }
    }
}
