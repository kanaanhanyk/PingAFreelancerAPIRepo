using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerCore.Entities;

public class Domain
{
    public int Id { get; set; }

    public required string Name { get; set; }
    public required string PhotoPath { get; set; }
    public ICollection<Freelancer> Freelancers { get; set; } = new List<Freelancer>();
    public ICollection<Expertise> Expertises { get; set; } = new List<Expertise>();
}
