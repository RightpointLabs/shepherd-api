using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FunctionApp.Models;

namespace FunctionApp.DataAccess
{
    public class MockRepository : IRepository
    {
        private List<Topic> Topics = new List<Topic>()
        {
            new Topic("Angular 6", "Show me how to get to Hello World using the CLI", "Jane Developer")
            {
                Id =  "d033a5d1-5346-4133-baa9-3db379a8ea8b",
                RequestedDate = DateTime.Parse("11/03/2018 11:15 AM"),
                Votes = 6
            },
            new Topic("Sketch", "I want to know how to publish design comps in Sketch. What are my options?", "Jeff Designer")
            {
                Id =  "35e837ae-d2fa-485d-a9ad-83f9e129b9e2",
                RequestedDate = DateTime.Parse("11/03/2018 11:26 AM"),
                Votes = 3
            }
        };

        private List<Commitment> Commitments = new List<Commitment>()
        {
            new Commitment("d033a5d1-5346-4133-baa9-3db379a8ea8b", "93501a1c-f832-44ba-95a6-0c968e6189d2", DateTime.Parse("11/09/2018 12:00 PM"), "Brain Food Friday")
            {
                Id = "c928a90b-1130-4315-a917-94f3971e9d6e",
                CommittedDate = DateTime.Parse("11/03/2018 11:24 AM")
            }
        };

        private List<Person> People = new List<Person>()
        {
            new Person("93501a1c-f832-44ba-95a6-0c968e6189d2", "Brandon Barnett")
        };

        public async Task<Commitment> AddCommitment(Commitment commitment)
        {
            // TODO: check if commitment exists
            // if(exists) throw new ObjectAlreadyExistsException();
            
            this.Commitments.Add(commitment);

            return commitment;
        }

        public async Task<Topic> AddTopic(Topic topic)
        {
            this.Topics.Add(topic);

            return topic;
        }

        public async Task DeleteCommitmentById(string id)
        {
            Commitment commitment = this.Commitments.SingleOrDefault(x => x.Id == id);

            if (commitment == null) throw new ObjectNotFoundException();

            this.Commitments.Remove(commitment);
        }

        public async Task DeleteTopicById(string id)
        {
            Topic topic = this.Topics.SingleOrDefault(x => x.Id == id);

            if (topic == null) throw new ObjectNotFoundException();

            this.Topics.Remove(topic);
        }

        public async Task<Commitment> GetCommitmentById(string id)
        {
            Commitment commitment = this.Commitments.SingleOrDefault(x => x.Id == id);

            if (commitment == null) throw new ObjectNotFoundException();

            return commitment;
        }

        public async Task<IEnumerable<Commitment>> GetCommitments()
        {
            return this.Commitments.AsEnumerable();
        }

        public async Task<Person> GetPersonById(string id)
        {
            Person person = this.People.SingleOrDefault(x => x.Id == id);

            if (person == null) throw new ObjectNotFoundException();

            return person;
        }

        public async Task<Topic> GetTopicById(string id)
        {
            Topic topic = this.Topics.SingleOrDefault(x => x.Id == id);

            if (topic == null) throw new ObjectNotFoundException();

            return topic;
        }

        public async Task<IEnumerable<Topic>> GetTopics()
        {
            return this.Topics.AsEnumerable();
        }

        public async Task<Person> UpsertPerson(Person person)
        {
            Person existingPerson = this.People.SingleOrDefault(x => x.Id == person.Id);

            if(existingPerson != null) return existingPerson;

            this.People.Add(person);

            return person;
        }
    }
}