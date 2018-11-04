using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionApp.Models;

namespace FunctionApp.DataAccess
{
    public class AzureCosmosGraphRepository : IRepository
    {
        public async Task<Commitment> AddCommitment(Commitment commitment)
        {
            throw new NotImplementedException();
        }

        public async Task<Topic> AddTopic(Topic topic)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public async Task<Person> UpsertPerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}