using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PingAFreelancerApplication.Entities;

namespace PingAFreelancerApplication.Data.Configurations;

public class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
{
    public void Configure(EntityTypeBuilder<Expertise> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
            
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.PhotoPath)
            .IsRequired()
            .HasMaxLength(255);

        entity.HasOne(e => e.Domain)
            .WithMany(d => d.Expertises)
            .HasForeignKey(e => e.DomainId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(e => e.Freelancers)
            .WithOne(f => f.Expertise)
            .HasForeignKey(f => f.ExpertiseId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}