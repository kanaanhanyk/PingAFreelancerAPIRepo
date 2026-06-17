using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Data;

public class PingAFreelancerContext : DbContext
{
    public PingAFreelancerContext(DbContextOptions<PingAFreelancerContext> options) : base(option)
    {

    }

    public DbSet<FreelancerProfile> Freelancers { get; set; }
    public DbSet<ClientProfile> Clients { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Domain> Domains { get; set; }
    public DbSet<Expertise> Expertises { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }


}
