using System;
using FunctionApp.Models;
using Gremlin.Net.CosmosDb.Structure;

namespace FunctionApp.DataAccess.GraphSchema
{
    [Label("topic")]
    public class TopicVertex : VertexBase
    {
        public string Title { get; set; }

        public string SuccessCriteria { get; set; }

        RequestEdge Requested { get; }
    }
}