using ApiTestingFramework.Endpoints.Requests;
using ApiTestingFramework.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using ApiTestingFramework.Endpoints.Attributes;

namespace ApiTestingFramework.Endpoints
{
    class Url
    {
        const string AppIdSetting = "AppId";
        const string UrlSetting = "Url";
        const string VersionSetting = "Version";

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

        Dictionary<string, string> parameters = new Dictionary<string, string>();

        public Url(Endpoint endpoint)
        {
            SetBaseUrlWithEndpoint(endpoint.EndpointName);
        }

        public Url(string fullUrl)
        {
            FullUrl = fullUrl;
        }

        static void SetBaseUrl() 
            => BaseUrl = CombineUrlParts(ConfigurationManager.AppSettings[UrlSetting], ConfigurationManager.AppSettings[VersionSetting]);

        static void SetBaseUrlWithEndpoint(string endpointUrl)
        {
            SetBaseUrl();
            BaseUrl = CombineUrlParts(BaseUrl, endpointUrl);
        }

        static string CombineUrlParts(params string[] urlParts) 
            => string.Join("/", urlParts);

        void AddUrlIdParameter() 
            => parameters.Add(AppIdSetting, ConfigurationManager.AppSettings[AppIdSetting]);

        void AddUnitsParameter(Request request)
        {
            WeatherUnitsAttribute unitsAttribute = request.GetType().GetCustomAttributes(typeof(WeatherUnitsAttribute), true).FirstOrDefault() as WeatherUnitsAttribute;
            if (unitsAttribute != null)
            {
                parameters.Add(nameof(unitsAttribute.units), unitsAttribute.units.ToString());
            }
        }

        void AddUrlParametersFromRequest(Request request)
            => parameters.AddRange(ObjectConverter.ConvertObjectToDictionary(request));

        string GetConstructedFullUrl() 
            => $"{BaseUrl}?{string.Join("", parameters?.Select(parameter => $"{parameter.Key}={parameter.Value}&").ToArray())}";

        public void SetUrlParameters(Request request)
        {
            AddUrlParametersFromRequest(request);
            AddUnitsParameter(request);
            AddUrlIdParameter();
        }
    }
}
