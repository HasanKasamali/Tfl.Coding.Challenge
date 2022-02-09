using Newtonsoft.Json;
using System;

namespace Tfl.Coding.Challenge.Infrastructure
{
    public class RoadStatusModel
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        [JsonProperty("statusSeverity")]
        public string RoadStatus { get; set; }

        [JsonProperty("statusSeverityDescription")]
        public string RoadStatusDescription { get; set; }

        public string Bounds { get; set; }

        public string Envelope { get; set; }

        public string Url { get; set; }

        public string SuccessCode { get; set; }
    }
}
