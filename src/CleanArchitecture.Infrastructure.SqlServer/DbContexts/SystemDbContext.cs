using CleanArchitecture.Orders.Infrastructure.SqlServer.EntityTypeConfigurations.Companies;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.DbContexts;

public class SystemDbContext(DbContextOptions<SystemDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("system");
        modelBuilder.ApplyConfiguration(new CompanyEntityTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}