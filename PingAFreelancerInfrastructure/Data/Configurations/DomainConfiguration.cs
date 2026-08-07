using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PingAFreelancerCore.Entities;

namespace PingAFreelancerInfrastructure.Data.Configurations;

public class DomainConfiguration : IEntityTypeConfiguration<Domain>
{
    public void Configure(EntityTypeBuilder<Domain> entity)
    {
        entity.HasKey(d => d.Id);

        entity.Property(d => d.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        entity.Property(d => d.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(d => d.PhotoPath)
            .IsRequired()
            .HasMaxLength(255);

        entity.HasMany(d => d.Freelancers)
            .WithOne(f => f.Domain)
            .HasForeignKey(f => f.DomainId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(d => d.Expertises)
            .WithOne(e => e.Domain)
            .HasForeignKey(e => e.DomainId)
            .OnDelete(DeleteBehavior.Restrict);


    }
    
}
