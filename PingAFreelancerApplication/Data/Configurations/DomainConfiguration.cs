using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PingAFreelancerApplication.Entities;

namespace PingAFreelancerApplication.Data.Configurations;

public class DomainConfiguration : IEntityTypeConfiguration<Domain>
{
    public void Configure(EntityTypeBuilder<Domain> entity)
    {
        entity.HasKey(d => d.Id);

        entity.Property(d => d.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        entity.Property(d => d.Name).IsRequired();
        entity.Property(d => d.PhotoPath).IsRequired();

        entity.HasMany(d => d.Freelancers)
            .WithOne(f => f.Domain)
            .HasForeignKey(f => f.DomainId);

        entity.HasMany(d => d.Expertises)
            .WithOne(e => e.Domain)
            .HasForeignKey(e => e.DomainId);
    }
    
}