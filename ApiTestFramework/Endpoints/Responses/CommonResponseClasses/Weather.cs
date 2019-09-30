namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Weather
    {
        public int? id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }

        public override string ToString()
        {
            return "{" +
                    "\"id\":" + id +
                    ",\"main\":" + main +
                    ",\"description\":" + description +
                    ",\"icon\":" + icon +
                    "}";
        }
    }
}
