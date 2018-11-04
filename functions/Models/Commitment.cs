using System;

namespace functions.Models
{
    public class Commitment
    {
        public string Id { get; set; }

        public string Teacher { get; set; }

        public DateTime CommittedDate { get; set; }

        public DateTime EventDate { get; set; }

        public string EventType { get; set; }

        public Topic Topic { get; set; }
    }
}