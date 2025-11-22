using GreenQuest.AI.Models;
using Microsoft.EntityFrameworkCore;

namespace GreenQuest.AI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>(entity =>
            {
                // CreatedAt se setează automat la inserare
                entity.Property(e => e.CreatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");

                // LastUpdatedAt se actualizează automat la modificare
                entity.Property(e => e.LastUpdatedAt)
                    .HasDefaultValueSql("GETUTCDATE()");
            });
        }
    }
}