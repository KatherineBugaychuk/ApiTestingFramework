using ApiTestingFramework.Endpoints.Responses;
using RestSharp;

namespace ApiTestingFramework.Execution
{
    class ResponseProcessor
    {
        public ResponseProcessor() { }

        public Response ExtractResponse(IRestResponse restResponse)
            => new Response((int)restResponse.StatusCode, restResponse.Content);
    }
}
