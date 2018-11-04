using System.Collections.Generic;
using System.Threading.Tasks;
using FunctionApp.Models;

namespace FunctionApp.DataAccess
{
    public interface IRepository
    {
        Task<Commitment> AddCommitment(Commitment commitment);

        Task<Topic> AddTopic(Topic topic);

        Task DeleteCommitmentById(string id);

        Task DeleteTopicById(string id);

        Task<Commitment> GetCommitmentById(string id);

        Task<Topic> GetTopicById(string id);

        Task<IEnumerable<Commitment>> GetCommitments();

        Task<IEnumerable<Topic>> GetTopics();
    }
}