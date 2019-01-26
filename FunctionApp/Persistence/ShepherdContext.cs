using FunctionApp.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace FunctionApp.Persistence
{
    public class ShepherdContext : DbContext
    {
        public DbSet<Commitment> Commitments { get; set; }
        public DbSet<CommitmentType> CommitmentTypes { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
    }
}