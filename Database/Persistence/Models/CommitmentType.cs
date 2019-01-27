using System.Collections.Generic;

namespace FunctionApp.Persistence.Models
{
    public class CommitmentType : DbModelBase
    {
        public string Name { get; set; }

        public ICollection<Commitment> Commitments { get; set; }
    }
}