using CleanArchitecture.Orders.Domain.Databases.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.Databases.EntityTypeConfigurations;

public class DatabaseEntityTypeConfiguration : IEntityTypeConfiguration<Database>
{
    public void Configure(EntityTypeBuilder<Database> builder)
    {
        builder.ToTable("Databases");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("DatabaseId")
            .IsRequired();
        builder.Property(p => p.ServerName)
            .IsRequired();
        builder.Property(p => p.DatabaseName)
            .IsRequired();
        builder.Property(p => p.UserName)
            .IsRequired();
        builder.Property(p => p.Password)
            .IsRequired();

    }
}