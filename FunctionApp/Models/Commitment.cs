using System;

namespace FunctionApp.Models
{
    public class Commitment
    {
        public string Id { get; set; }

        public string Teacher { get; set; }

        public DateTime CommittedDate { get; set; }

        public DateTime EventDate { get; set; }

        public string EventType { get; set; }

        public Topic Topic { get; set; }

        public Commitment(string teacher, DateTime eventDate, string eventType)
        {
            if(String.IsNullOrEmpty(teacher)) throw new ArgumentNullException(nameof(teacher));
            if(eventDate < DateTime.UtcNow) throw new ArgumentOutOfRangeException(nameof(eventDate), "Event cannot occur in the past");
            if(String.IsNullOrEmpty(eventType)) throw new ArgumentNullException(nameof(eventType));

            this.Teacher = teacher;
            this.EventDate = eventDate;
            this.EventType = eventType;

            this.Id = Guid.NewGuid().ToString();
            this.CommittedDate = DateTime.UtcNow;
        }
    }
}