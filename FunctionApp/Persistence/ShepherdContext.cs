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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ConfigureCommitments(modelBuilder);
            ConfigureCommitmentTypes(modelBuilder);
            ConfigureTopics(modelBuilder);
            ConfigureUsers(modelBuilder);
        }

        private static void ConfigureModelBase<T>(ModelBuilder modelBuilder) where T : DbModelBase
        {
            modelBuilder.Entity<T>()
                .Property(b => b.Id)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(b => b.CreatedDate)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(b => b.UpdatedDate)
                .IsRequired();
        }

        private static void ConfigureCommitments(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<Commitment>(modelBuilder);

            modelBuilder.Entity<Commitment>()
                .Property(b => b.UserId)
                .IsRequired();

            modelBuilder.Entity<Commitment>()
                .Property(b => b.TypeId)
                .IsRequired();

            modelBuilder.Entity<Commitment>()
                .Property(b => b.Date)
                .IsRequired();
        }

        private static void ConfigureCommitmentTypes(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<CommitmentType>(modelBuilder);

            modelBuilder.Entity<CommitmentType>()
                .Property(b => b.Name)
                .HasMaxLength(50)
                .IsRequired();
        }

        private static void ConfigureTopics(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<Topic>(modelBuilder);

            modelBuilder.Entity<Topic>()
                .Property(b => b.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Topic>()
                .Property(b => b.AcceptanceCriteria)
                .HasMaxLength(1000)
                .IsRequired();

            modelBuilder.Entity<Topic>()
                .Property(b => b.UserId)
                .IsRequired();
        }

        private static void ConfigureUsers(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<User>(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(b => b.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(b => b.TenantId)
                .HasMaxLength(100)
                .IsRequired();
        }
    }
}