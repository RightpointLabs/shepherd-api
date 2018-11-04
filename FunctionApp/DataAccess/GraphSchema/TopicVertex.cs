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

        public DateTime RequestedDate { get; set; }

        public Topic ToTopic()
        {
            return new Topic
            {
                Id = base.Id,
                Title = this.Title,
                SuccessCriteria = this.SuccessCriteria            
            };
        }
    }
}