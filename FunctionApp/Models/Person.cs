using System;

namespace FunctionApp.Models
{
    public class Person
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public Person(string id, string name)
        {
            if(String.IsNullOrEmpty(id)) throw new ArgumentNullException(nameof(id));
            if(String.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            this.Id = id;
            this.Name = name;
        }
    }
}