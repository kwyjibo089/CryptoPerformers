using System.Collections.Generic;
using System.Net;
using DataService.Models;
using Newtonsoft.Json;

namespace DataService
{
    public class CryptoDataService
    {
        public string ApiUrl { get; set; }

        public List<ICryptoData> GetCryptoData()
        {
            var client = new WebClient();
            client.UseDefaultCredentials = true;
            var data = client.DownloadString(ApiUrl);

            return FromJson(data);
        }

        private static List<ICryptoData> FromJson(string json)
        {
            return JsonConvert.DeserializeObject<List<ICryptoData>>(json, Converter.Settings);
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