using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace CryptoPerformers
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly ISettings _settings = CrossSettings.Current;
        private readonly string apiUrl = "https://api.coinmarketcap.com/v1/ticker/?limit=100";
        private readonly string iconPath = "https://files.coinmarketcap.com/static/img/coins/32x32/{0}.png";
        private readonly string dbPath = "CryptoPerformersSQLite.db3";
        private readonly bool isFirstStart = true;

        public string ApiUrl
        {
            get => _settings.GetValueOrDefault("ApiUrl", apiUrl);
            set => _settings.AddOrUpdateValue("ApiUrl", value);
        }

        public string IconPath
        {
            get => _settings.GetValueOrDefault("iconPath", iconPath);
            set => _settings.AddOrUpdateValue("iconPath", value);
        }

        public string DbPath
        {
            get => _settings.GetValueOrDefault("dbPath", apiUrl);
            set => _settings.AddOrUpdateValue("dbPath", value);
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
        string DbPath { get; set; }
        bool IsFirstStart { get; set; }
    }
}