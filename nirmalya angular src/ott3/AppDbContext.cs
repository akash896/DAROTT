using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ott3.Models;

using System.Collections.Generic;
using System.Reflection.Metadata;

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
            optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=ott;Trusted_Connection=True;TrustServerCertificate=True");
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<User>()
                .HasMany(e => e.UserSessions)
                .WithOne(e => e.user)
                .HasForeignKey(e => e.userUid)
                .HasPrincipalKey(e => e.uid);*/
            /*modelBuilder.Entity<Blog>()
                .HasMany(e => e.Posts)
                .WithOne(e => e.Blog)
                .HasForeignKey(e => e.BlogId)
                .HasPrincipalKey(e => e.Id);*/
        }
        public virtual DbSet<BasicFile> Files { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserSession> UserSessions { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<MoviePoster> MoviePosters { get; set; }
        public virtual DbSet<MoviePreview> MoviePreviews { get; set; }
        public virtual DbSet<MovieFile> MovieFiles { get; set; }
        public virtual DbSet<AudioLanguage> AudioLanguages { get; set; }
        public virtual DbSet<SubtitleLanguage> SubtitleLanguages { get; set; }
        public virtual DbSet<Crew> Crews { get; set; }
        public virtual DbSet<CrewCategory> CrewCategories { get; set; }
        // public virtual DbSet<Horoscope> Horoscopes { get; set; }
    }
}
