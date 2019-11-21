using ApiTestingFramework.Endpoints.Requests;
using ApiTestingFramework.Endpoints.Responses;
using ApiTestingFramework.Execution;
using ApiTestingFramework.Validation;
using Newtonsoft.Json;

namespace ApiTestingFramework.Tests
{
    class CommonForWeatherTests : EndpointsContainer
    {
        public CommonResponse SendRequestCheckResponse(Request request, CommonResponse expectedResponse, RequestType requestType = RequestType.Get)
        {
            Response response = WeatherEndpoint.SendGetRequest(request).Execute().GetResponse(0);
            CommonResponse actualResponse = JsonConvert.DeserializeObject<CommonResponse>(response.ResponseBody);
            Comparator.CompareObjects(actualResponse, expectedResponse);
            return actualResponse;
        }

        public void SendRequestCheckResponseWithValidation(Request request, CommonResponse expectedResponse, RequestType requestType = RequestType.Get)
        {
            Validator.ValidateMandatory(SendRequestCheckResponse(request, expectedResponse, requestType));
        }
    }
}
