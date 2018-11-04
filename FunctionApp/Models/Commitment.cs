using System;

namespace FunctionApp.Models
{
    public class Commitment
    {
        public string Id { get; set; }

        public string PersonId { get; set; }

        public string TopicId { get; set; }

        public DateTime CommittedDate { get; set; }

        public DateTime EventDate { get; set; }

        public string EventType { get; set; }

        public Commitment(string topicId, string personId, DateTime eventDate, string eventType)
        {
            if (String.IsNullOrEmpty(topicId)) throw new ArgumentNullException(nameof(topicId));
            if (String.IsNullOrEmpty(personId)) throw new ArgumentNullException(nameof(personId));
            if (eventDate < DateTime.UtcNow) throw new ArgumentOutOfRangeException(nameof(eventDate), "Event cannot occur in the past");
            if (String.IsNullOrEmpty(eventType)) throw new ArgumentNullException(nameof(eventType));

            this.PersonId = personId;
            this.TopicId = topicId;
            this.EventDate = eventDate;
            this.EventType = eventType;

            this.Id = Guid.NewGuid().ToString();
            this.CommittedDate = DateTime.UtcNow;
        }
    }
}