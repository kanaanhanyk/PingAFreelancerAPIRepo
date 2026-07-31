using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerCore.Entities;

public class Expertise
{
    public int Id { get; set; } 

    public int DomainId { get; set; }
    public Domain Domain { get; set; }
    public required string Name { get; set; }
    public required string PhotoPath { get; set; }
    public ICollection<Freelancer> Freelancers { get; set; } = new List<Freelancer>();
}
