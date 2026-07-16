using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PingAFreelancerApplication.Entities;

namespace PingAFreelancerApplication.Data.Configurations;

public class FreelancerConfiguration : IEntityTypeConfiguration<Freelancer>
{
    public void Configure(EntityTypeBuilder<Freelancer> entity)
    {
        entity.HasKey(f => f.Id);
        entity.Property(f => f.Id).IsRequired();
        entity.Property(f => f.FirstName).IsRequired();
        entity.Property(f => f.LastName).IsRequired();
        entity.Property(f => f.Latitude).IsRequired();
        entity.Property(f => f.Longitude).IsRequired();
        entity.Property(f => f.PhotoPath).IsRequired();
        entity.Property(f => f.IsActive).IsRequired();
        entity.Property(f => f.PhoneNumber).IsRequired();

        entity.HasOne(f => f.Domain)
            .WithMany(d => d.Freelancers)
            .HasForeignKey(f => f.DomainId);

        entity.HasOne(f => f.Expertise)
            .WithMany(e => e.Freelancers)
            .HasForeignKey(f => f.ExpertiseId);

        entity.HasMany(f => f.Contracts)
            .WithOne(c => c.Freelancer)
            .HasForeignKey(c => c.FreelancerId);

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

        entity.Property(f => f.RatingSum)
            .IsRequired()
            .HasDefaultValue(0);

        entity.Property(f => f.IsActive)
            .IsRequired()
            .HasDefaultValue(true);
    }
}