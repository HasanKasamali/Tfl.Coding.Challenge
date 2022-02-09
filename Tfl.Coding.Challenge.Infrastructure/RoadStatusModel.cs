using System;

namespace Tfl.Coding.Challenge.Infrastructure
{
    public class RoadStatusModel
    {
        public string Id { get; set; }

        public string DisplayName { get; set; }

        public string RoadStatus { get; set; }

        public string RoadStatusDescription { get; set; }

        public string Bounds { get; set; }

        public string Envelope { get; set; }

        public string Url { get; set; }

        public string SuccessCode { get; set; }
    }
}
