using System;

namespace ApiTestingFramework.Endpoints.Attributes
{
    class CommaSeparatedValues : Attribute
    {
        public int CountMin { get; set; } = 1;
        public int CountMax { get; set; } = 100;
    }
}
