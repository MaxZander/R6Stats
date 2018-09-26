// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var stats = Stats.FromJson(jsonString);

namespace API
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Stats
    {
        [JsonProperty("player")]
        public Player Player { get; set; }
    }

    public partial class Player
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("platform")]
        public string Platform { get; set; }

        [JsonProperty("ubisoft_id")]
        public string UbisoftId { get; set; }

        [JsonProperty("indexed_at")]
        public DateTimeOffset IndexedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }

        [JsonProperty("stats")]
        public StatsClass Stats { get; set; }
    }

    public partial class StatsClass
    {
        [JsonProperty("ranked")]
        public Casual Ranked { get; set; }

        [JsonProperty("casual")]
        public Casual Casual { get; set; }

        [JsonProperty("overall")]
        public Dictionary<string, long> Overall { get; set; }

        [JsonProperty("progression")]
        public Progression Progression { get; set; }
    }

    public partial class Casual
    {
        [JsonProperty("has_played")]
        public bool HasPlayed { get; set; }

        [JsonProperty("wins")]
        public long Wins { get; set; }

        [JsonProperty("losses")]
        public long Losses { get; set; }

        [JsonProperty("wlr")]
        public double Wlr { get; set; }

        [JsonProperty("kills")]
        public long Kills { get; set; }

        [JsonProperty("deaths")]
        public long Deaths { get; set; }

        [JsonProperty("kd")]
        public double Kd { get; set; }

        [JsonProperty("playtime")]
        public double Playtime { get; set; }
    }

    public partial class Progression
    {
        [JsonProperty("level")]
        public long Level { get; set; }

        [JsonProperty("xp")]
        public long Xp { get; set; }
    }

    public partial class Stats
    {
        public static Stats FromJson(string json) => JsonConvert.DeserializeObject<Stats>(json, API.Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Stats self) => JsonConvert.SerializeObject(self, API.Converter.Settings);
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

