using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class FreelancerProfile
{
    public string Id { get; set; } 
    public virtual UserProfile User { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
    public int DomainId { get; set; }
    public Domain Domain { get; set; }
    public int ExpertiseId { get; set; }
    public Expertise Expertise { get; set; }
    public decimal HourlyRate { get; set; }
    public int HoursBilled { get; set; }
    public decimal AverageRating { get; set; }
    public int TotalInteractions { get; set; }
    public Persona Persona { get; set; } = Persona.Freelancer;
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
