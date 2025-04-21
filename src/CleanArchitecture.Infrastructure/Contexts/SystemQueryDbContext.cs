using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Contexts;

public class SystemQueryDbContext(DbContextOptions<SystemQueryDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SystemDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}