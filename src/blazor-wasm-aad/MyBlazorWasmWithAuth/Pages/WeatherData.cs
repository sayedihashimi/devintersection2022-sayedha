using System.Text.Json.Serialization;

namespace MyBlazorWasmWithAuth.Pages {
    public class WeatherData {
        public string? Product { get; set; }
        
        [JsonPropertyName("init")]
        public string? Date { get; set; }
        
        [JsonPropertyName("dataseries")]
        public List<WeatherDetails>? Forecasts { get;set;}
    }
    public class WeatherDetails {
        [JsonPropertyName("date")]
        public int DateInt { get; set; }

        [JsonPropertyName("weather")]
        public string? Summary { get; set; }

        [JsonPropertyName("temp2m")]
        public Temp? Temp { get; set; }

        [JsonPropertyName("wind10m_max")]
        public int Wind { get; set; }
    }
    public class Temp {
        public int Min { get; set; }
        [JsonIgnore]
        public int MinF => (int)Math.Round(9m / 5m * Min + 32);

        public int Max { get; set; }
        [JsonIgnore]
        public int MaxF => (int)Math.Round(9m / 5m * Max + 32);
    }
}
