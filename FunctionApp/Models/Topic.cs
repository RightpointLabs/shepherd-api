using System;

namespace FunctionApp.Models
{
    public class Topic : DbModelBase
    {
        public string Name { get; set; }

        public string AcceptanceCriteria { get; set; }

        public Guid UserId { get; set; }
    }
}