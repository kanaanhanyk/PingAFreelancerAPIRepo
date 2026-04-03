using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class Domain
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string PhotoPath { get; set; }
    public string BorderColor { get; set; }
    public ICollection<FreelancerProfile> Freelancers { get; set; } = new List<FreelancerProfile>();
    public ICollection<Expertise> Expertises { get; set; } = new List<Expertise>();

}
