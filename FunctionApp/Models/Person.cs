using System;

namespace FunctionApp.Models
{
    public class Person
    {
        public string Id { get; set; }

        public string ExternalId { get; set; }

        public string Name { get; set; }

        public Person() { }

        public Person(string externalId, string name)
        {
            if (String.IsNullOrEmpty(externalId)) throw new ArgumentNullException(nameof(externalId));
            if (String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            this.ExternalId = externalId;
            this.Name = name;
        }
    }
}