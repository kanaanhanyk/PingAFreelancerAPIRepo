using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class Freelancer
{
    public Guid Id { get; set; } 

    public string PhoneNumber { get; set; } = string.Empty;
    public int DomainId { get; set; }
    public Domain Domain { get; set; }
    public int ExpertiseId { get; set; }
    public Expertise Expertise { get; set; }
    public decimal HourlyRate { get; set; }
    public int HoursBilled { get; set; }
    public int InteractionCount { get; set; }
    public decimal RatingSum { get; set; }

    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string? DisplayName { get; set; } = string.Empty;

    public DateTimeOffset DateRegistered { get; set; }
    public string PhotoPath { get; set; } = string.Empty;
    public bool IsActive { get; set; }

    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}
