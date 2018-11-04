using System;
using FunctionApp.Models;
using Gremlin.Net.CosmosDb.Structure;

namespace FunctionApp.DataAccess.GraphSchema
{
    [Label("topic")]
    public class TopicVertex : VertexBase, IDomainMap<Topic, TopicVertex>
    {
        public string Title { get; set; }

        public string SuccessCriteria { get; set; }

        public DateTime RequestedDate { get; set; }

        public TopicVertex FromDomain(Topic model)
        {
            this.Id = model.Id;
            this.Title = model.Title;
            this.SuccessCriteria = model.SuccessCriteria;

            return this;
        }

        public Topic ToDomain()
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