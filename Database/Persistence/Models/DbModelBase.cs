using System;

namespace FunctionApp.Persistence.Models
{
    public abstract class DbModelBase
    {
        public Guid Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime UpdatedDate { get; set; }
    }
}