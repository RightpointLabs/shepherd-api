using System;

namespace Shared.Persistence.Models
{
    public class Commitment : DbModelBase
    {
        public DateTime Date { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public Guid TypeId { get; set; }

        public CommitmentType Type { get; set; }
    }
}