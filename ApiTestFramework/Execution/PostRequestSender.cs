using ApiTestFramework.Endpoints.Requests;
using ApiTestFramework.Endpoints.Responses;
using RestSharp;

namespace ApiTestFramework.Execution
{
    class PostRequestSender : RequestSender
    {
        public PostRequestSender(Request request) : base(request)
        {
        }

        public override Response Send()
        {
            Request.RestRequest.Method = Method.POST;
            return ResponseProcessor.ExtractResponse(RestClient.Execute(Request.RestRequest));
        }
    }
}
