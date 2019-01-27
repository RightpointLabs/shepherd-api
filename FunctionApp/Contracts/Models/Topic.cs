using System;
using System.Collections.Generic;

namespace FunctionApp.Contracts.Models
{
    public class Topic
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string AcceptanceCriteria { get; set; }

        public Guid RequestorId { get; set; }

        public string RequestorName { get; set; }

        public int Votes { get; set; }

        public IEnumerable<Commitment> Commitments { get; set; }
    }
}