using Microsoft.EntityFrameworkCore;
using TripWeave.Api.Models;

namespace TripWeave.Api.Data;

public class TripWeaveDbContext : DbContext
{
    public TripWeaveDbContext(
        DbContextOptions<TripWeaveDbContext> options)
        : base(options)
    {
    }

    public DbSet<Trip> Trips => Set<Trip>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Trip>(entity =>
        {
            entity.HasKey(t => t.Id);

            entity.Property(t => t.Destination)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(t => t.Budget)
                .HasPrecision(12, 2);
        });
    }
}
