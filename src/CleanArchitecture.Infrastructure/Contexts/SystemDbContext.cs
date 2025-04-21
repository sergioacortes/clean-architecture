using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infrastructure.Contexts;

public class SystemDbContext(DbContextOptions<SystemDbContext> options) : DbContext(options)
{
    internal const string Schema = "System";
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema(Schema);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SystemDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}