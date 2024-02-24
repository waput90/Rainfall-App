using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Rainfall.API.Models
{
    public class RainfallResponse
    {
        [JsonProperty("@context")]
        public string Context { get; set; }
        public RainfallMeta Meta { get; set; }
        public RainfallItem[] Items { get; set; }
    }

    public class RainfallMeta
    {
        public string Publisher { get; set; }
        public string Licence { get; set; }
        public string Documentation { get; set; }
        public string Version { get; set; }
        public string Comment { get; set; }
        public string[] HasFormat { get; set; }
        public int Limit { get; set; }
    }

    public class RainfallItem
    {
        [JsonProperty("@id")]
        public string Id { get; set; }
        public string DateTime { get; set; }
        public string Measure { get; set; }
        public decimal Value { get; set; }
    }
}
