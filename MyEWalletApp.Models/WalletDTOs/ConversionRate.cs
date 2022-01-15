using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyEWalletApp.Models.WalletDTOs
{
    public class ConversionRate
    {
        [JsonProperty("success", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Success { get; set; }

        [JsonProperty("timestamp", NullValueHandling = NullValueHandling.Ignore)]
        public long? Timestamp { get; set; }

        [JsonProperty("base", NullValueHandling = NullValueHandling.Ignore)]
        public string Base { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? Date { get; set; }

        [JsonProperty("rates", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, double> Rates { get; set; }
    }
}
