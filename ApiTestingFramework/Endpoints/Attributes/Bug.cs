using System;

namespace ApiTestingFramework.Endpoints.Attributes
{
    class Bug : Attribute
    {
        public string Description { get; set; }

        public Bug(string description)
        {
            Description = description;
        }
    }
}

