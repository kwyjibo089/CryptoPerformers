using System;
using System.Collections.Generic;
using System.Text;

namespace CryptoPerformers.Models
{
    public class CryptoOverviewViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal PriceUsd { get; set; }
        public decimal PercentChange1H { get; set; }
        public decimal PercentChange24H { get; set; }
        public decimal PercentChange7D { get; set; }
        public string ImgSrc { get; set; }
    }
}
