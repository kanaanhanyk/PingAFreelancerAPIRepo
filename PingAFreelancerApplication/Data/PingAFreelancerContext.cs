using System.Buffers.Text;
using System.Runtime.Intrinsics.Arm.Arm64;
using System;
using System.Collections.Generic;
using System.Text;
using PingAFreelancerApplication.Entities;
using Microsoft.EntityFrameworkCore;

namespace PingAFreelancerApplication.Data;

public class PingAFreelancerContext : DbContext
{
    public PingAFreelancerContext(DbContextOptions<PingAFreelancerContext> options) : base(options)
    {

    }

    public DbSet<Freelancer> Freelancers { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Domain> Domains { get; set; }
    public DbSet<Expertise> Expertises { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.Entity<Freelancer>(entity =>
        {
            entity.HasKey(f => f.Id);
            entity.Property(f => f.Id).ValueGeneratedOnAdd();
            entity.Property(f => f.FirstName).IsRequired();
            entity.Property(f => f.LastName).IsRequired();
            entity.Property(f => f.Latitude).IsRequired();
            entity.Property(f => f.Longitude).IsRequired();
            entity.Property(f => f.DateRegistered).IsRequired();
            entity.Property(f => f.PhotoPath).IsRequired();
            entity.Property(f => f.IsActive).IsRequired();
            entity.Property(f => f.PhoneNumber).IsRequired();

            entity.HasOne(f => f.Domain).WithMany(d => d.Freelancers).HasForeignKey(f => f.DomainId);
            entity.HasOne(f => f.Expertise).WithMany(e => e.Freelancers).HasForeignKey(f => f.ExpertiseId);
        });
    }


}
