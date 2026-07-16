using PingAFreelancerApplication.Entities;

namespace PingAFreelancerApplication.Data.Configuration;

public class ContractConfiguration : IEntityTypeConfiguration<Contract>
{
    public void Configure(EntityTypeBuilder<Contract> entity)
    {
        entity.HasKey(c => c.Id);
    }
}