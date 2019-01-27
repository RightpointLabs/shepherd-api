using System.IO;
using Shared.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.Extensions.Configuration;

namespace Database
{
    public class ShepherdContext : DbContext
    {
        public DbSet<Commitment> Commitments { get; set; }
        public DbSet<CommitmentType> CommitmentTypes { get; set; }
        public DbSet<Topic> Topics { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var configuration = builder.Build();

            optionsBuilder.UseSqlServer(configuration["connectionString"]);
        }

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
                .Property(x => x.Id)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.CreatedDate)
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.UpdatedDate)
                .IsRequired();
        }

        private static void ConfigureCommitments(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<Commitment>(modelBuilder);

            modelBuilder.Entity<Commitment>()
                .Property(x => x.UserId)
                .IsRequired();

            modelBuilder.Entity<Commitment>()
                .Property(x => x.TypeId)
                .IsRequired();

            modelBuilder.Entity<Commitment>()
                .Property(x => x.Date)
                .IsRequired();

            modelBuilder.Entity<Commitment>()
                .HasOne(x => x.Type)
                .WithMany(x => x.Commitments)
                .IsRequired();
        }

        private static void ConfigureCommitmentTypes(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<CommitmentType>(modelBuilder);

            modelBuilder.Entity<CommitmentType>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }

        private static void ConfigureTopics(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<Topic>(modelBuilder);

            modelBuilder.Entity<Topic>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Topic>()
                .Property(x => x.AcceptanceCriteria)
                .HasMaxLength(1000)
                .IsRequired();

            modelBuilder.Entity<Topic>()
                .Property(x => x.RequestorId)
                .IsRequired();

            modelBuilder.Entity<Topic>()
                .HasOne(x => x.Requestor)
                .WithMany(x => x.Topics)
                .IsRequired();
        }

        private static void ConfigureUsers(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<User>(modelBuilder);

            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .Property(x => x.TenantId)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<User>()
                .HasMany(x => x.Commitments)
                .WithOne(x => x.User);
        }
    }
}