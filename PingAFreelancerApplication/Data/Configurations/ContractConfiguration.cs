using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PingAFreelancerApplication.Entities;

namespace PingAFreelancerApplication.Data.Configurations;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> entity)
    {
        entity.HasKey(c => c.Id);

        entity.Property(c => c.Id)
            .IsRequired()
            .ValueGeneratedNever();

        entity.HasOne(c => c.Client)
            .WithMany(c => c.Contracts)
            .HasForeignKey(c => c.ClientId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(c => c.Freelancer)
            .WithMany(f => f.Contracts)
            .HasForeignKey(c => c.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.Property(c => c.DatePinged)
            .IsRequired()
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        entity.Property(c => c.ProposalMessage)
            .HasMaxLength(2000);

        entity.Property(c => c.Review)
            .HasMaxLength(2000);
    }
}