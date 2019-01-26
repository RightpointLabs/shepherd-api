using System.Collections.Generic;

namespace FunctionApp.Persistence.Models
{
    public class User : DbModelBase
    {
        public string Name { get; set; }

        public string TenantId { get; set; }

        public ICollection<Topic> Topics { get; set; }

        public ICollection<Commitment> Commitments { get; set; }
    }
}