namespace CryptoPerformers.Models
{
    public interface ICryptoData
    {
        string Id { get; set; }
        string Name { get; set; }
        string Symbol { get; set; }
        string Rank { get; set; }
        string PriceUsd { get; set; }
        string PriceBtc { get; set; }
        string The24HVolumeUsd { get; set; }
        string MarketCapUsd { get; set; }
        string AvailableSupply { get; set; }
        string TotalSupply { get; set; }
        string MaxSupply { get; set; }
        string PercentChange1H { get; set; }
        string PercentChange24H { get; set; }
        string PercentChange7D { get; set; }
        string LastUpdated { get; set; }
    }
}