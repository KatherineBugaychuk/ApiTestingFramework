using ApiTestingFramework.Endpoints.Requests;
using ApiTestingFramework.Endpoints.Responses;
using RestSharp;

namespace ApiTestingFramework.Execution
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
