using System.Collections.Generic;
using System.Net;
using CryptoPerformers.Models;
using Newtonsoft.Json;

namespace CryptoPerformers.Services
{
    public class CryptoDataService
    {
        public string ApiUrl { get; set; }

        public List<CryptoData> GetCryptoData()
        {
            var client = new WebClient();
            var data = client.DownloadString(ApiUrl);

            return FromJson(data);
        }

        private static List<CryptoData> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<CryptoData>>(json, Converter.Settings);
        }
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None
        };
    }
}