using System;
using System.Collections.Generic;

namespace FunctionApp.Persistence.Models
{
    public class Topic : DbModelBase
    {
        public string Name { get; set; }

        public string AcceptanceCriteria { get; set; }

        public Guid RequestorId { get; set; }

        public User Requestor { get; set; }

        public ICollection<Commitment> Commitments { get; set; }
    }
}