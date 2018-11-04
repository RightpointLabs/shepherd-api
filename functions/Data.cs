using System;
using System.Collections.Generic;
using System.Linq;
using functions.Models;

namespace functions
{
    public static class Data
    {
        public static List<Topic> Topics = new List<Topic>()
        {
            new Topic
            {
                Id =  "d033a5d1-5346-4133-baa9-3db379a8ea8b",
                Title = "Angular 6",
                SuccessCriteria = "Show me how to get to Hello World using the CLI",
                Requestor = "Jane Developer",
                RequestedDate = DateTime.Parse("11/03/2018 11:15 AM"),
                Votes = 6,
                // Commitments = Commitments.Where(x => x.Id == "d033a5d1-5346-4133-baa9-3db379a8ea8b").ToList()
            },
            new Topic
            {
                Id =  "35e837ae-d2fa-485d-a9ad-83f9e129b9e2",
                Title = "Sketch",
                SuccessCriteria = "I want to know how to publish design comps in Sketch. What are my options?",
                Requestor = "Jeff Designer",
                RequestedDate = DateTime.Parse("11/03/2018 11:26 AM"),
                Votes = 3,
                // Commitments = Commitments.Where(x => x.Id == "35e837ae-d2fa-485d-a9ad-83f9e129b9e2")
            }
        };

        public static List<Commitment> Commitments = new List<Commitment>()
        {
            new Commitment
            {
                Id = "c928a90b-1130-4315-a917-94f3971e9d6e",
                Teacher = "Joe Architect",
                CommittedDate = DateTime.Parse("11/03/2018 11:24 AM"),
                EventDate = DateTime.Parse("11/09/2018 12:00 PM"),
                EventType = "Brain Food Friday",
                Topic = new Topic()
            }
        };
    }
}