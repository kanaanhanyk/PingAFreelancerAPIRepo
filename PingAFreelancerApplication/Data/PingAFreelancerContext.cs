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
        builder.ApplyConfigurationsFromAssembly(typeof(PingAFreelancerContext).Assembly);
    }
}
