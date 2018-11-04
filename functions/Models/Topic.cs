using System;
using System.Collections.Generic;

namespace functions.Models
{
    public class Topic
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string SuccessCriteria { get; set; }

        public string Requestor { get; set; }

        public DateTime RequestedDate { get; set; }

        public int Votes { get; set; }

        public IEnumerable<Commitment> Commitments { get; set; }
    }
}