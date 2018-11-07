using System;
using Gremlin.Net.CosmosDb.Structure;

namespace FunctionApp.DataAccess.GraphSchema
{
    [Label("committedTo")]
    public class CommitmentEdge : EdgeBase<PersonVertex, TopicVertex>
    {
        public DateTime CommittedDate { get; set; }

        public DateTime EventDate { get; set; }

        public string EventType { get; set; }
    }
}