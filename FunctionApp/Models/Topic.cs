using System;
using System.Collections.Generic;

namespace FunctionApp.Models
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

        public Topic() { }

        public Topic(string title, string successCriteria, string requestor)
        {
            if (String.IsNullOrEmpty(title)) throw new ArgumentNullException(nameof(title));
            if (String.IsNullOrEmpty(successCriteria)) throw new ArgumentNullException(nameof(successCriteria));
            if (String.IsNullOrEmpty(requestor)) throw new ArgumentNullException(nameof(requestor));

            this.Title = title;
            this.SuccessCriteria = successCriteria;
            this.Requestor = requestor;

            this.Id = Guid.NewGuid().ToString();
            this.RequestedDate = DateTime.UtcNow;
        }
    }
}