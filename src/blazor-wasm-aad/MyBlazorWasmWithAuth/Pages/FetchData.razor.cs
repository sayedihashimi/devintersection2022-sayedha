using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using System.Net.Http;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Routing;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using Microsoft.AspNetCore.Components.WebAssembly.Http;
using Microsoft.JSInterop;
using MyBlazorWasmWithAuth;
using MyBlazorWasmWithAuth.Shared;
using MyBlazorWasmWithAuth.Components;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MyBlazorWasmWithAuth.Pages
{
    public partial class FetchData
    {
        private WeatherForecast[]? forecasts;
        private WeatherData? weatherData;
        private LocationInfo[]? locations;
        private List<string>? states;
        private List<string>? cities;
        public string currentState="NV";
        public string currentCity;
        protected override async Task OnInitializedAsync()
        {
            // Las Vegas
            var lat = "36.16";
            var lon = "115.13";
            weatherData = await Http.GetFromJsonAsync<WeatherData>(@$"https://www.7timer.info/bin/api.pl?lon={lon}&lat={lat}&product=civillight&output=json");

            locations = await Http.GetFromJsonAsync<LocationInfo[]>(@"uscities.json");
            var loc1 = locations[0];

            states = locations.Select(x => x.StateId).Distinct().ToList();
            states.Sort();
            




            forecasts = await Http.GetFromJsonAsync<WeatherForecast[]>("sample-data/weather.json");
        }

        public class WeatherForecast
        {
            public DateTime Date { get; set; }
            public int TemperatureC { get; set; }

            public string? Summary { get; set; }

            public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
        }
    }

    public class WeatherData {
        public string? Product { get; set; }
        
        [JsonPropertyName("init")]
        public string? Date { get; set; }
        
        [JsonPropertyName("dataseries")]
        public List<WeatherDetails>? Forecasts { get;set;}
    }
    public class WeatherDetails
    {
        [JsonPropertyName("date")]
        public int DateInt { get; set; }
        
        [JsonPropertyName("weather")]
        public string? Summary { get; set; }
        
        [JsonPropertyName("temp2m")]
        public Temp? Temp { get; set; }
        
        [JsonPropertyName("wind10m_max")]
        public int Wind { get; set; }
    }
    public class Temp
    {
        public int Min { get; set; }
        public int Max { get; set; }
    }
}
