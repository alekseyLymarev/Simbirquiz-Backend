using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SimbirSquize.Data.Dtos;

namespace SimbirSquize.Data.Testing
{
    public class TestingContext : DbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<TestAnswer> TestAnswer { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        public DbSet<Score> Scores { get; set; }

        public DbSet<Achivment> Achivments { get; set; }

        public DbSet<UserAchivment> USersAchivments { get; set; }
        
        public DbSet<UserProfile> UserProfiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TestAnswer>(e => e.HasKey(t => new {TestId = t.QuestionId, t.Id}));

            modelBuilder
                .Entity<Score>()
                .HasKey(e => new {e.UserId, e.CourseId});

            modelBuilder
                .Entity<UserAchivment>()
                .HasKey(e => new {e.UserId, e.AchivmentId});

            base.OnModelCreating(modelBuilder);
        }

        public TestingContext(DbContextOptions<TestingContext> options)
            : base(options)
        {
        }


        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            AddTimestamps();
            return await base.SaveChangesAsync();
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity &&
                            (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow; // current datetime

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity) entity.Entity).CreatedAt = now;
                }

                ((BaseEntity) entity.Entity).UpdatedAt = now;
            }
        }
    }
}