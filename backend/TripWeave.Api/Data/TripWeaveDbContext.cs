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
}
