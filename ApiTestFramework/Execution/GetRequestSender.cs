using ApiTestFramework.Endpoints.Requests;
using ApiTestFramework.Endpoints.Responses;
using RestSharp;

namespace ApiTestFramework.Execution
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
