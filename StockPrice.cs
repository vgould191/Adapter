using Newtonsoft.Json;

namespace AdapterExample
{
    /**
     * this class is the "prices" data from RapidAPI call
     * */
    class StockPrice
    {
        [JsonProperty(PropertyName = "date")]
        public int Date { get; set; }
        [JsonProperty(PropertyName = "open")]
        public double Open { get; set; }
        [JsonProperty(PropertyName = "high")]
        public double High { get; set; }
        [JsonProperty(PropertyName = "low")]
        public double Low { get; set; }
        [JsonProperty(PropertyName = "close")]
        public double Close { get; set; }
        [JsonProperty(PropertyName = "volume")]
        public int Volume { get; set; }
        [JsonProperty(PropertyName = "adjclose")]
        public double AdjClose { get; set; }
    }
}
