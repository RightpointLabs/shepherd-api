using FunctionApp.Models;
using Gremlin.Net.CosmosDb.Structure;

namespace FunctionApp.DataAccess.GraphSchema
{
    [Label("person")]
    public class PersonVertex : VertexBase, IDomainMap<Person, PersonVertex>
    {
        public string ExternalId { get; set; }

        public string Name { get; set; }

        public PersonVertex FromDomain(Person model)
        {
            this.Id = model.Id;
            this.ExternalId = model.ExternalId;
            this.Name = this.Name;

            return this;
        }

        public Person ToDomain()
        {
            return new Person
            {
                Id = base.Id,
                ExternalId = this.ExternalId,
                Name = this.Name
            };
        }
    }
}