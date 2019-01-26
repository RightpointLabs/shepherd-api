using System;

namespace FunctionApp.Persistence.Models
{
    public class Commitment : DbModelBase
    {
        public Guid UserId { get; set; }

        public Guid TypeId { get; set; }

        public DateTime Date { get; set; }
    }
}