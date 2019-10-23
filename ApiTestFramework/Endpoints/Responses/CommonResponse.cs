using ApiTestFramework.Endpoints.Responses.CommonResponseClasses;
namespace ApiTestFramework.Endpoints.Responses
{
    class CommonResponse
    {
        public Coord coord { get; set; } = null;
        public Sys sys { get; set; } = null;
        public Weather[] weather { get; set; } = null;
        public string @base { get; set; } = null;
        public Main main { get; set; } = null;
        public Wind wind { get; set; } = null;
        public Rain rain { get; set; } = null;
        public Clouds clouds { get; set; } = null;
        public string dt { get; set; } = null;
        public int? id { get; set; } = null;
        public string name { get; set; } = null;
        public int? cod { get; set; } = null;
        public string message { get; set; } = null;
        public int? visibility { get; set; } = null;
        public int? timezone { get; set; } = null;

        public CommonResponse()
        {
        }

        public CommonResponse(int  cod)
        {
            this.cod = cod;
        }

        public CommonResponse(string name, int cod)
        {
            this.name = name;
            this.cod = cod;
        }

        public CommonResponse(string name, int cod, string country)
        {
            this.name = name;
            this.cod = cod;
            SetSys(new Sys(country));
        }

        public CommonResponse SetCoord(Coord coord)
        {
            this.coord = coord;
            return this;
        }

        public CommonResponse SetSys(Sys sys)
        {
            this.sys = sys;
            return this;
        }

        public CommonResponse SetWeather(Weather[] weather)
        {
            this.weather = weather;
            return this;
        }

        public CommonResponse SetBase(string @base)
        {
            this.@base = @base;
            return this;
        }

        public CommonResponse SetMain(Main main)
        {
            this.main = main;
            return this;
        }

        public CommonResponse SetWind(Wind wind)
        {
            this.wind = wind;
            return this;
        }

        public CommonResponse SetRain(Rain rain)
        {
            this.rain = rain;
            return this;
        }

        public CommonResponse SetClouds(Clouds clouds)
        {
            this.clouds = clouds;
            return this;
        }

        public CommonResponse SetDt(string dt)
        {
            this.dt = dt;
            return this;
        }

        public CommonResponse SetId(int id)
        {
            this.id = id;
            return this;
        }

        public CommonResponse SetName(string name)
        {
            this.name = name;
            return this;
        }

        public CommonResponse SetCod(int cod)
        {
            this.cod = cod;
            return this;
        }

        public CommonResponse SetMessage(string message)
        {
            this.message = message;
            return this;
        }

        public CommonResponse SetVisibility(int visibility)
        {
            this.visibility = visibility;
            return this;
        }

        public CommonResponse SetTimezone(int timezone)
        {
            this.timezone = timezone;
            return this;
        }
    }
}
