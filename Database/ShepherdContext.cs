using System;
using System.IO;
using System.Linq;
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
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("newid()")
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("getutcdate()")
                .IsRequired();

            modelBuilder.Entity<T>()
                .Property(x => x.UpdatedDate)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("getutcdate()")
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
                .HasOne(x => x.User)
                .WithMany(x => x.Commitments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Commitment>()
                .HasOne(x => x.Type)
                .WithMany(x => x.Commitments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Commitment>()
                .HasOne(x => x.Topic)
                .WithMany(x => x.Commitments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }

        private static void ConfigureCommitmentTypes(ModelBuilder modelBuilder)
        {
            ConfigureModelBase<CommitmentType>(modelBuilder);

            modelBuilder.Entity<CommitmentType>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<CommitmentType>()
                .HasData(
                    new CommitmentType { Id = new Guid("e130479b-8009-4941-a3ee-f0292bbcfe23"), Name = "BFF" },
                    new CommitmentType { Id = new Guid("0a196ec9-4d23-4a32-84ff-dbf0852a898e"), Name = "Blog post" },
                    new CommitmentType { Id = new Guid("606c603f-3997-4f5f-b115-b7629075428a"), Name = "Lightning talk" }
                );
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

            modelBuilder.Entity<User>()
                .HasData(
                    new User { Id = new Guid("1d982bf6-a353-4741-867c-ed2c46090984"), Name = "Brandon Barnett", TenantId = "Test" }
                );
        }
    }
}