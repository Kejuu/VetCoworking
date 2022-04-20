using Microsoft.EntityFrameworkCore;
using VetCoworking.Domain.Models;

namespace AQ.Core.Persistence
{
    public partial class VetCoworkingContext : DbContext
    {
        public VetCoworkingContext()
        {
        }

        public VetCoworkingContext(DbContextOptions<VetCoworkingContext> options)
            : base(options)
        {
        }

        public VetCoworkingContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return NpgsqlDbContextOptionsBuilderExtensions.UseNpgsql(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public virtual DbSet<Booking> Booking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .IsClustered(false);
            });
        }
    }
}


