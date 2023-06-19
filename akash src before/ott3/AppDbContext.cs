using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ott3.Models.poll;
using ott3.Models;

using System.Collections.Generic;
using ott3.Models.horoscope;
using ott3.Models.eventPage;

namespace ott3
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() // : base("StudentDB_Annotation")
        {
            try
            {
                var databaseCreator = (Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator);
                // databaseCreator.CreateTables();
            }
            catch (Exception e)
            {
                //A SqlException will be thrown if tables already exist. So simply ignore it.
            }
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-H1EGS2I\SQLEXPRESS;Initial Catalog=ottAkash;Persist Security Info=True;User ID=user1;Password=12345;TrustServerCertificate=True");
            // optionsBuilder.UseSqlServer(@"Server=DESKTOP-H1EGS2I\\SQLEXPRESS;Integrated Security=True;Database=StudentDB_Annotation;User Id=user1;Password=12345;");
            // "Data Source=DESKTOP-H1EGS2I\\SQLEXPRESS;Initial Catalog=ott;Integrated Security=True"
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries().Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).updatedAt = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).createdAt = DateTime.Now;
                    ((BaseEntity)entityEntry.Entity).createdBy = ((BaseEntity)entityEntry.Entity).updatedBy;
                }
            }
            return base.SaveChanges();
        }
        public virtual DbSet<BasicFile> Files { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }

        // Horoscope related tables
        public virtual DbSet<Horoscope> Horoscopes { get; set; }
        
        // Vote related tables
        public virtual DbSet<Models.vote.Vote> Votes { get; set; }
        public virtual DbSet<Models.vote.VoteSummary> VoteSummaries { get; set; }

        // Vote related tables
        public virtual DbSet<Poll> Polls { get; set; }
        public virtual DbSet<PollSummary> PollSummaries { get; set; }
        public virtual DbSet<EventPage> EventPages { get; set; }
    }
}
