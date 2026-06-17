using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class Expertise
{
    public int Id { get; set; } 
    public int DomainId { get; set; }
    public Domain Domain { get; set; }
    public string Name { get; set; }
    public string BorderColor { get; set; }
    public string PhotoPath { get; set; }
    public ICollection<Freelancer> Freelancers { get; set; } = new List<FreelancerProfile>();
}
