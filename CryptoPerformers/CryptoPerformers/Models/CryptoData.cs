using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CryptoPerformers.Models
{
    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using CryptoFeed;
    //
    //    var data = CryptoData.FromJson(jsonString);

    public class CryptoData
    {
        [JsonProperty("id")] public string Id { get; set; }

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("symbol")] public string Symbol { get; set; }

        [JsonProperty("rank")] public string Rank { get; set; }

        [JsonProperty("price_usd")] public string PriceUsd { get; set; }

        [JsonProperty("price_btc")] public string PriceBtc { get; set; }

        [JsonProperty("24h_volume_usd")] public string The24HVolumeUsd { get; set; }

        [JsonProperty("market_cap_usd")] public string MarketCapUsd { get; set; }

        [JsonProperty("available_supply")] public string AvailableSupply { get; set; }

        [JsonProperty("total_supply")] public string TotalSupply { get; set; }

        [JsonProperty("max_supply")] public string MaxSupply { get; set; }

        [JsonProperty("percent_change_1h")] public string PercentChange1H { get; set; }

        [JsonProperty("percent_change_24h")] public string PercentChange24H { get; set; }

        [JsonProperty("percent_change_7d")] public string PercentChange7D { get; set; }

        [JsonProperty("last_updated")] public string LastUpdated { get; set; }
    }

    public static class Serialize
    {
        public static string ToJson(this List<CryptoData> self)
        {
            return JsonConvert.SerializeObject(self, Converter<,>.Settings);
        }
    }
}