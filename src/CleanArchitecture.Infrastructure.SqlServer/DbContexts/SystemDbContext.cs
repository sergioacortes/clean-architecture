using CleanArchitecture.Orders.Domain.Companies.Entities;
using CleanArchitecture.Orders.Domain.Databases.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.DbContexts;

public class SystemDbContext(DbContextOptions<SystemDbContext> options) : DbContext(options)
{
    
    public DbSet<Company> Companies { get; set; }
    
    public DbSet<Database> Databases { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SystemDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}