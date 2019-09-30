using ApiTestFramework.Endpoints.Responses;
using System.Collections.Generic;

namespace ApiTestFramework.Execution
{
    class RequestExecutor
    {
        public List<ISenderCommand> commands;
        public List<Response> Responses { get; set; }

        public RequestExecutor(List<ISenderCommand> commands)
        {
            this.commands = commands;
            Responses = new List<Response>();
        }

        public void Execute()
        {
            if (commands != null)
            {
                commands.ForEach(command => Responses.Add(command.Send()));
            }
        }
    }
}
