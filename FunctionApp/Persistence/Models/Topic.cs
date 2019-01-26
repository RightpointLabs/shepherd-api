using System;

namespace FunctionApp.Persistence.Models
{
    public class Topic : DbModelBase
    {
        public string Name { get; set; }

        public string AcceptanceCriteria { get; set; }

        public Guid UserId { get; set; }
    }
}