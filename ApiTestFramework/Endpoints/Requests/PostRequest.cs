using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestFramework.Endpoints.Requests
{
    class PostRequest : Request
    {
        public PostRequest(Url requestUrl, string endpointName)
        {
            requestUrl.SetUrlParameters(this);
            RestRequest = new RestRequest(RequestUrl.FullUrl, Method.POST);
        }
    }
}
