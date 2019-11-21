using RestSharp;
using System.Collections.Generic;

namespace ApiTestingFramework.Endpoints.Requests
{
    class GetRequest : Request
    {
        public GetRequest()
        {
        }

        public override void PrepareRequest(Endpoint endpoint, Dictionary<string, string> headers, string url)
        {
            base.PrepareRequest(endpoint, headers, url);
            RequestUrl.SetUrlParameters(this);
            RestRequest = new RestRequest(RequestUrl.FullUrl, Method.GET);
        }
    }
}
