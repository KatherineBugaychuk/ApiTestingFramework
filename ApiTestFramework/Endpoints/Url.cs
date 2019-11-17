using ApiTestFramework.Endpoints.Requests;
using ApiTestFramework.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;

namespace ApiTestFramework.Endpoints
{
    class Url
    {
        string fullUrl;
        public string FullUrl
        {
            get
            {
                return string.IsNullOrEmpty(fullUrl) ? GetConstructedFullUrl() : fullUrl;
            }
            private set
            {
                fullUrl = value;
            }
        }
        public static string BaseUrl { get; set; }
        static string AppIdUrlParameter { get; set; }
        Dictionary<string, string> parameters;

        public Url(Endpoint endpoint)
        {
            SetBaseUrlWithEndpoint(endpoint.EndpointName);
            SetAppIdUrlParameter();
        }

        public Url(string fullUrl)
        {
            FullUrl = fullUrl;
        }

        static void SetBaseUrl() 
            => BaseUrl = CombineUrlParts(ConfigurationManager.AppSettings["Url"], ConfigurationManager.AppSettings["Version"]);

        static void SetBaseUrlWithEndpoint(string endpointUrl)
        {
            SetBaseUrl();
            BaseUrl = CombineUrlParts(BaseUrl, endpointUrl);
        }

        private static string CombineUrlParts(params string[] urlParts) => string.Join("/", urlParts);

        static void SetAppIdUrlParameter() 
            => AppIdUrlParameter = ConfigurationManager.AppSettings["AppId"];

        public Dictionary<string, string> SetParametersFromClass(Request request) 
            => parameters = ObjectConverter.ConvertObjectToDictionary(request);

        private string GetConstructedFullUrl() 
            => $"{BaseUrl}?{string.Join("", parameters?.Select(parameter => $"{parameter.Key}={parameter.Value}&").ToArray())}APPID={AppIdUrlParameter}";
    }
}
