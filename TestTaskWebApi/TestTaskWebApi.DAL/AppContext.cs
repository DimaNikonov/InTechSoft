using Microsoft.EntityFrameworkCore;
using TestTaskWebApi.DAL.Entitties;

namespace TestTaskWebApi.DAL
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FaqGroup> FaqGroups { get; set; }

        public DbSet<FaqQuestion> FaqQuestions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FaqGroup>()
                .HasMany(c => c.FaqQuestions)
                .WithOne(e => e.FaqGroup)
                .IsRequired();
        }
    }
}
