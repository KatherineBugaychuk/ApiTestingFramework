using ApiTestingFramework.Endpoints.Requests;
using ApiTestingFramework.Endpoints.Responses;
using ApiTestingFramework.Execution;
using System.Collections.Generic;
using System.Linq;

namespace ApiTestingFramework.Endpoints
{
    class Endpoint
    {
        RequestExecutor requestExecutor;
        Dictionary<string, string> headers;
        public List<Response> AllResponses => requestExecutor.Responses;
        public string EndpointName { get; protected set; }
        List<ISenderCommand> commands;

        public Endpoint()
        {
            commands = new List<ISenderCommand>();
            requestExecutor = new RequestExecutor(commands);
            SetDefaultHeaders();
        }

        void SetDefaultHeaders()
        {
            headers = new Dictionary<string, string>()
            {
                { "Content-Type", "application/json" }
            };
        }

        public Endpoint SendGetRequest(Request request)
        {
            request.PrepareRequest(this, headers, "");
            commands.Add(new GetRequestSender(request));
            return this;
        }

        public Endpoint SendGetRequest(Request request, string url)
        {
            request.PrepareRequest(this, headers, url);
            commands.Add(new GetRequestSender(request));
            return this;
        }

        public Endpoint SendPostRequest(Request request)
        {
            request.PrepareRequest(this, headers, "");
            commands.Add(new PostRequestSender(request));
            return this;
        }

        public Endpoint AddHeaders(Dictionary<string, string> headers)
        {
            headers.ToList().ForEach(header => this.headers.Add(header.Key, header.Value));
            return this;
        }

        public List<Response> GetResponses(params int[] indexesOfResponses)
            => indexesOfResponses.Select(index => new Response(requestExecutor.Responses[index])).ToList();      

        public Response GetResponse(int indexOfResponse)
            => requestExecutor.Responses[indexOfResponse];
        

        public Endpoint Execute()
        {
            requestExecutor.Execute();
            return this;
        }
    }
}