using System.Text.Json.Serialization;

namespace MyBlazorWasmWithAuth {
    public class LocationInfo {
        public string City { get; set; }
        public string State { get; set; }
        public string StateId { get; set; }
        [JsonPropertyName("lat")]
        public decimal Latitude { get; set; }
        [JsonPropertyName("long")]
        public decimal Longitude { get; set; }
    }
}
