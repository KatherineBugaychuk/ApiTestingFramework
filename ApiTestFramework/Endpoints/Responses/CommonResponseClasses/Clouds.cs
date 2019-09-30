namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Clouds
    {
        public int? all { get; set; }

        public override string ToString()
        {
            return "{" +
                    "\"all\":" + all +
                    "}";
        }
    }
}
