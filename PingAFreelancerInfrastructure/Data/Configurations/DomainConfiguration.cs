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

        entity.HasData(
            new Domain
            {
                Id = -1,
                Name = "Labor",
                PhotoPath = "labor.png",
            },
            new Domain
            {
                Id = -2,
                Name = "Domestic",
                PhotoPath = "domestic.png",
            },
            new Domain
            {
                Id = -3,
                Name = "Health",
                PhotoPath = "health.png",
            },
            new Domain
            {
                Id = -4,
                Name = "Lifestyle",
                PhotoPath = "lifestyle.png",
            },
            new Domain
            {
                Id = -5,
                Name = "Tech",
                PhotoPath = "tech.png",
            }
        );
    }
    
}
