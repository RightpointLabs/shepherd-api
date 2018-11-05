using FunctionApp.Models;
using Gremlin.Net.CosmosDb.Structure;

namespace FunctionApp.DataAccess.GraphSchema
{
    [Label("person")]
    public class PersonVertex : VertexBase
    {
        public string ExternalId { get; set; }

        public string Name { get; set; }
    }
}