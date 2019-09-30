namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Sys
    {
        public string type { get; set; }
        public int? id { get; set; }
        public string message { get; set; }
        public string country { get; set; }
        public int? sunrise { get; set; }
        public int? sunset { get; set; }

        public Sys()
        {
        }

        public Sys(string country)
        {
            this.country = country;
        }

        public override string ToString()
        {
            return "{" +
                    "\"type\":" + type +
                    ",\"id\":" + id +
                    ",\"message\":" + message +
                    ",\"country\":" + country +
                    ",\"sunrise\":" + sunrise +
                    ",\"sunset\":" + sunset +
                    "}";
        }
    }
}
