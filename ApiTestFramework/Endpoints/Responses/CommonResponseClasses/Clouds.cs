namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Clouds
    {
        public int? all { get; set; }

        public string GetString()
        {
            return "{" +
                    "\"all\":" + all +
                    "}";
        }
    }
}
