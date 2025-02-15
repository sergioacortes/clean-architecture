using CleanArchitecture.Orders.Domain.Companies.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Orders.Infrastructure.SqlServer.Companies.EntityTypeConfigurations;

public class CompanyEntityTypeConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .HasColumnName("CompanyId")
            .IsRequired();
        builder.Property(p => p.TradeName)
            .IsRequired();
    }
}