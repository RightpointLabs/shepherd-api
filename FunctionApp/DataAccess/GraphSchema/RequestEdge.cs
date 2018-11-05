using System;
using Gremlin.Net.CosmosDb.Structure;

namespace FunctionApp.DataAccess.GraphSchema
{
    [Label("requested")]
    public class RequestEdge : EdgeBase<PersonVertex, TopicVertex>
    {
        public DateTime RequestedDate { get; set; }
    }
}