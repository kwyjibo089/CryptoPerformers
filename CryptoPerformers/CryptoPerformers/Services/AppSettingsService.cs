using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CryptoPerformers
{
    public class AppSettingsServiceService : IAppSettingsService
    {
        private readonly ISettings _settings = CrossSettings.Current;
        private readonly string apiUrl = "https://api.coinmarketcap.com/v1/ticker/?limit=100";
        private readonly bool isFirstStart;

        public string ApiUrl
        {
            get => _settings.GetValueOrDefault("ApiUrl", apiUrl);
            set => _settings.AddOrUpdateValue("ApiUrl", value);
        }

        public bool IsFirstStart
        {
            get => _settings.GetValueOrDefault("IsFirstStart", isFirstStart);
            set => _settings.AddOrUpdateValue("IsFirstStart", value);
        }
    }

    public interface IAppSettingsService
    {
        string ApiUrl { get; set; }

        bool IsFirstStart { get; set; }
    }
}