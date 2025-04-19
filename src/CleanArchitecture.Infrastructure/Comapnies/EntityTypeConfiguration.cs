using CleanArchitecture.Domain;
using CleanArchitecture.Domain.Companies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Comapnies;

public class EntityTypeConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("Id");
        builder.Property(x => x.TradeName)
            .HasColumnName("TradeName")
            .HasMaxLength(DomainConstants.MaxColumnLength);
    }
}