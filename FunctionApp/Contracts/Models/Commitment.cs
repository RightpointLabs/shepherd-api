using System;
using System.Collections.Generic;

namespace FunctionApp.Contracts.Models
{
    public class Commitment
    {
        public Guid Id { get; set; }

        public string ExpertName { get; set; }

        public DateTime EventDate { get; set; }

        public Guid EventTypeId { get; set; }

        public string EventTypeName { get; set; }
    }
}