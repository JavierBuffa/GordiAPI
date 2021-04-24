using System;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace API.DTOs
{
    public class SummonerDTO
    {

        public string Id { get; set; }
        public string AccountId { get; set; }
        public string PuuId { get; set; }
        public string Name { get; set; }
        public int ProfileIconId { get; set; }
       // [JsonConverter(typeof(DateTimeConverter))]
       // public Int64 RevisionDate { get; set; }
        public int SummonerLevel { get; set; }
        
    }
}