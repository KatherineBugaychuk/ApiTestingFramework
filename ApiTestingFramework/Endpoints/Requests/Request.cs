using ApiTestingFramework.Endpoints.Attributes;
using ApiTestingFramework.Endpoints.Requests.Get.Weather;
using RestSharp;
using System.Collections.Generic;

namespace ApiTestingFramework.Endpoints.Requests
{
    public enum RequestType { Get, Post, Put, Delete };

    [WeatherUnits(units = WeatherUnits.metric)]
    class Request
    {
        public Url RequestUrl { get; set; }
        public Dictionary<string, string> Headers { get; set; }
        public RestRequest RestRequest { get; set; }

        public virtual void PrepareRequest(Endpoint endpoint, Dictionary<string, string> headers, string fullUrl)
        {
            if (endpoint == null || endpoint.EndpointName == null)
                return;
            Headers = headers;
            RequestUrl = string.IsNullOrEmpty(fullUrl) ? new Url(endpoint) : new Url(fullUrl);
        }
    }
}
