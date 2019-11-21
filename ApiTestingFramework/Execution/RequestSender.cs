using ApiTestingFramework.Endpoints.Requests;
using ApiTestingFramework.Endpoints.Responses;
using RestSharp;
using System;
using System.Linq;

namespace ApiTestingFramework.Execution
{
    abstract class RequestSender : ISenderCommand
    {
        public RestClient RestClient { get; set; }
        public ResponseProcessor ResponseProcessor { get; set; }
        public Request Request { get; set; }

        public RequestSender(Request request)
        {
            Request = request;
            Validator.ValidateRequest(Request);
            ResponseProcessor = new ResponseProcessor();
            RestClient = new RestClient(Request.RequestUrl.FullUrl);
            Console.WriteLine("URL: " + Request.RequestUrl.FullUrl);
            Request.Headers.ToList().ForEach(header => Request.RestRequest.AddHeader(header.Key, header.Value));
        }

        public abstract Response Send();
    }
}
