using ApiTestFramework.Endpoints.Responses;
using RestSharp;

namespace ApiTestFramework.Execution
{
    class ResponseProcessor
    {
        public ResponseProcessor() { }

        public Response ExtractResponse(IRestResponse restResponse)
            => new Response((int)restResponse.StatusCode, restResponse.Content);
    }
}
