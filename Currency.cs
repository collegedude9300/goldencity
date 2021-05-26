// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using GoldenCities;
//
//    var welcome = Currency.FromJson(jsonString);

namespace GoldenCities.ClassModels
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Currency
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("terms")]
        public string Terms { get; set; }

        [JsonProperty("privacy")]
        public string Privacy { get; set; }

        [JsonProperty("timestamp")]
        public long Timestamp { get; set; }

        [JsonProperty("source")]
        public string Source { get; set; }

        [JsonProperty("quotes")]
        public Dictionary<string, double> Quotes { get; set; }
    }

    public partial class Currency
    {
        public static Currency FromJson(string json) => JsonConvert.DeserializeObject<Currency>(json, GoldenCities.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Currency self) => JsonConvert.SerializeObject(self, GoldenCities.Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}
