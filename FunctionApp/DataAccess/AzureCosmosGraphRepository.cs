using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionApp.DataAccess.GraphSchema;
using FunctionApp.Models;
using Gremlin.Net.CosmosDb;

namespace FunctionApp.DataAccess
{
    public class AzureCosmosGraphRepository : IRepository
    {
        private readonly GraphClient _graphClient;

        public AzureCosmosGraphRepository(string host, string db, string graph, string key)
        {
            this._graphClient = new GraphClient(host, db, graph, key);
        }

        public async Task<Commitment> AddCommitment(Commitment commitment)
        {
            throw new NotImplementedException();
        }

        public async Task<Topic> AddTopic(Topic topic)
        {
            var g = this._graphClient.CreateTraversalSource();

            var query = g.AddV<TopicVertex>(new TopicVertex().FromDomain(topic));

            var response = await this._graphClient.QueryAsync<TopicVertex>(query);

            return response.Single().ToDomain();
        }

        public async Task DeleteCommitmentById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteTopicById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Commitment> GetCommitmentById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Commitment>> GetCommitments()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Commitment>> GetCommitmentsByTopicId(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Person>> GetPeople()
        {
            var g = this._graphClient.CreateTraversalSource();

            var query = g.V<PersonVertex>();

            var response = await this._graphClient.QueryAsync<PersonVertex>(query);

            return response.Select(x => x.ToDomain());
        }

        public async Task<Person> GetPersonById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<Topic> GetTopicById(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            var g = this._graphClient.CreateTraversalSource();

            var query = g.V<TopicVertex>();

            var response = await this._graphClient.QueryAsync<TopicVertex>(query);

            return response.Select(x => x.ToDomain());
        }

        public async Task<Person> UpsertPerson(Person person)
        {
            var g = this._graphClient.CreateTraversalSource();

            var query = g.AddV<PersonVertex>(new PersonVertex { ExternalId = person.ExternalId, Name = person.Name });

            var response = await this._graphClient.QueryAsync<PersonVertex>(query);

            return response.Single().ToDomain();
        }
    }
}