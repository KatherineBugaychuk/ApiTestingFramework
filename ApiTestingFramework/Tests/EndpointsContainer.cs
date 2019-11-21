using ApiTestingFramework.Endpoints.EnpointTypes;
using NUnit.Framework;

namespace ApiTestingFramework.Tests
{
    class EndpointsContainer
    {
        public WeatherEndpoint WeatherEndpoint { get; set; } 
        public FindEndpoint FindEndpoint { get; set; } 
        public GroupEndpoint GroupEndpoint { get; set; }
        public NonExistingEndpoint NonExistingEndpoint { get; set; } 

        [SetUp]
        public void SetEndpointsContainer()
        {
            WeatherEndpoint = new WeatherEndpoint();
            FindEndpoint = new FindEndpoint();
            GroupEndpoint = new GroupEndpoint();
            NonExistingEndpoint = new NonExistingEndpoint();
        }
    }
}
