using System;

namespace FunctionApp.Contracts
{
    public class CreateCommitmentRequest
    {
        public string PersonId { get; set; }

        public DateTime EventDate { get; set; }

        public string EventType { get; set; }
    }
}