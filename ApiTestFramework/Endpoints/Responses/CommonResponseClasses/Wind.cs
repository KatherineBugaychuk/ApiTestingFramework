namespace ApiTestFramework.Endpoints.Responses.CommonResponseClasses
{
    class Wind
    {
        public double? speed { get; set; }
        public int? deg { get; set; }

        public override string ToString()
        {
            return "{" +
                    "\"speed\":" + speed +
                    ",\"deg\":" + deg +
                    "}";
        }
    }
}
