using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PingAFreelancerCore.Entities;

namespace PingAFreelancerInfrastructure.Data.Configurations;

public class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
{
    public void Configure(EntityTypeBuilder<Freelancer> entity)
    {
        entity.HasKey(f => f.Id);

        entity.Property(f => f.Id)
            .IsRequired()
            .ValueGeneratedNever();

        entity.Property(f => f.Email)
            .IsRequired()
            .HasMaxLength(255);

        entity.HasIndex(f => f.Email);

        entity.Property(f => f.FirstName)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(f => f.LastName)
            .HasMaxLength(100);

        entity.Property(f => f.PhoneNumber)
            .HasMaxLength(32);

        entity.Property(f => f.PhotoPath)
            .IsRequired()
            .HasMaxLength(255);

        entity.HasOne(f => f.Domain)
            .WithMany(d => d.Freelancers)
            .HasForeignKey(f => f.DomainId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(f => f.Expertise)
            .WithMany(e => e.Freelancers)
            .HasForeignKey(f => f.ExpertiseId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(f => f.Contracts)
            .WithOne(c => c.Freelancer)
            .HasForeignKey(c => c.FreelancerId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.Property(f => f.DateRegistered)
            .IsRequired()
            .HasDefaultValueSql("SYSDATETIMEOFFSET()");

        entity.Property(f => f.HourlyRate)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(f => f.HoursBilled)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(f => f.InteractionCount)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(f => f.TotalEarned)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(f => f.RatingSum)
            .IsRequired()
            .HasDefaultValue(0);

    }
}
