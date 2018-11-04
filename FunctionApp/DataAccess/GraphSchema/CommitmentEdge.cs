using System;
using Gremlin.Net.CosmosDb.Structure;

namespace FunctionApp.DataAccess.GraphSchema
{
    [Label("commitment")]
    public class CommitmentEdge : EdgeBase
    {
        public DateTime CommittedDate { get; set; }

        public DateTime EventDate { get; set; }

        public string EventType { get; set; }
    }
}