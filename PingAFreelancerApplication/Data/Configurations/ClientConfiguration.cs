using PingAFreelancerApplication.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PingAFreelancerApplication.Data.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> entity)
    {
        entity.HasKey(c => c.Id);

        entity.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedNever();

        entity.Property(c => c.DisplayName)
            .IsRequired();

        entity.Property(c => c.Email)
            .IsRequired();

        entity.HasIndex(c => c.Email);

        entity.Property(c => c.DateRegistered)
            .IsRequired()
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        entity.Property(c => c.TotalSpent)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(c => c.HoursBilled)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(c => c.InteractionCount)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(c => c.RatingSum)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(c => c.IsActive)
            .IsRequired()
            .HasDefaultValue(true);

        entity.HasMany(c => c.Contracts)
            .WithOne(c => c.Client)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}