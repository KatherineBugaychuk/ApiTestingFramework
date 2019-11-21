using ApiTestingFramework.Endpoints.Requests;
using ApiTestingFramework.Endpoints.Responses;
using RestSharp;

namespace ApiTestingFramework.Execution
{
    class GetRequestSender : RequestSender
    {
        public GetRequestSender(Request request) : base(request)
        {
        }

        public override Response Send()
        {
            Request.RestRequest.Method = Method.GET;
            return ResponseProcessor.ExtractResponse(RestClient.Execute(Request.RestRequest));
        }
    }
}
