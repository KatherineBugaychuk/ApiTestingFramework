using RestSharp;
using System;
using System.Collections.Generic;

namespace ApiTestFramework.Endpoints.Requests
{
    class GetRequest : Request
    {
        public GetRequest()
        {
        }

        public override void PrepareRequest(Endpoint endpoint, Dictionary<string, string> headers, string url)
        {
            base.PrepareRequest(endpoint, headers, url);
            RequestUrl.SetParametersFromClass(this);
            RestRequest = new RestRequest(RequestUrl.FullUrl, Method.GET);
        }
    }
}
