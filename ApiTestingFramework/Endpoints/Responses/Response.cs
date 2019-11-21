using System;

namespace ApiTestingFramework.Endpoints.Responses
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

        public Response(Response response)
        {
            ResponseCode = response.ResponseCode;
            ResponseBody = response.ResponseBody;
        }
    }
}
