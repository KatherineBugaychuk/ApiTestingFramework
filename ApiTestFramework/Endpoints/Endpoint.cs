using ApiTestFramework.Endpoints.Requests;
using ApiTestFramework.Endpoints.Responses;
using ApiTestFramework.Execution;
using System.Collections.Generic;
using System.Linq;

namespace ApiTestFramework.Endpoints
{
    class Endpoint
    {
        RequestExecutor requestExecutor;
        Dictionary<string, string> headers;
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

        public List<Response> GetAllResponses()
        {
            return requestExecutor.Responses;
        }

        // todo: refactor
        public List<Response> GetResponses(params int[] indexesOfResponses)
        {
            List<Response> responses = new List<Response>();
            indexesOfResponses.OfType<int>().ToList().ForEach(index => responses.Add(requestExecutor.Responses[index]));
            return responses;
        }

        public Response GetResponse(int indexOfResponse)
        {
            return requestExecutor.Responses[indexOfResponse];
        }

        public Endpoint Execute()
        {
            requestExecutor.Execute();
            return this;
        }
    }
}