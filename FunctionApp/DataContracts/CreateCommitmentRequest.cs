using System;

namespace FunctionApp.DataContracts
{
    public class CreateCommitmentRequest
    {
        public string TopicId { get; set; }

        public string Teacher { get; set; }

        public DateTime EventDate { get; set; }

        public string EventType { get; set; }
    }
}