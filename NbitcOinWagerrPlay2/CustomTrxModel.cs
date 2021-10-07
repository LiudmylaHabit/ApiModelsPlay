using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace NbitcOinWagerrPlay2
{
    public class CustomTrxModel
    {
        [JsonProperty("blockHash")]
        public string BlockHash { get; set; }

        [JsonProperty("blockHeight")]
        public int BlockHeight { get; set; }

        [JsonProperty("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonProperty("txId")]
        public string TxId { get; set; }

        [JsonProperty("version")]
        public int Version { get; set; }

        [JsonProperty("vin")]
        public List<Vin> Vin { get; set; }

        [JsonProperty("vout")]
        public List<Vout> Vout { get; set; }
    }

    public class Vin
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }

    public class Vout
    {
        [JsonProperty("_id")]
        public string Id { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("n")]
        public int N { get; set; }

        [JsonProperty("value")]
        public double Value { get; set; }
    }
}

