using ApiTestFramework.Endpoints.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestFramework.Execution
{
    interface ISenderCommand
    {
        Response Send();
    }
}
