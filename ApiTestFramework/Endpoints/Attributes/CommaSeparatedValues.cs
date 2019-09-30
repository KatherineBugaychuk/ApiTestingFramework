using System;

namespace ApiTestFramework.Endpoints.Attributes
{
    class CommaSeparatedValues : Attribute
    {
        public int CountMin { get; set; } = 1;
        public int CountMax { get; set; } = 100;
    }
}
