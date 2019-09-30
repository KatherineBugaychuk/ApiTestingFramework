using System;

namespace ApiTestFramework.Endpoints.Responses
{
    class Response
    {
        public int ResponseCode { get; set; }
        public string ResponseBody { get; set; }

        public Response()
        {
        }

        public Response(int responseCode)
        {
            ResponseCode = responseCode;
        }

        public Response(int responseCode, String responseBody)
        {
            ResponseCode = responseCode;
            ResponseBody = responseBody;
        }
    }
}
