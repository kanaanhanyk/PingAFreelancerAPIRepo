using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class Freelancer
{
    public Guid Id { get; set; } 

    public required string Email { get; set; }
    public string? PhoneNumber { get; set; } 

    public int DomainId { get; set; }
    public Domain Domain { get; set; }
    public int ExpertiseId { get; set; }
    public Expertise Expertise { get; set; }

    public decimal HourlyRate { get; set; }
    public int HoursBilled { get; set; }
    public decimal TotalEarned { get; set; }
    public int InteractionCount { get; set; }
    public int RatingSum { get; set; }

    public required string FirstName { get; set; }
    public string? LastName { get; set; } 

    public DateTimeOffset DateRegistered { get; set; }
    public required string PhotoPath { get; set; }
    public string AvatarColor { get; set; } = "#FFFFFF";

    public DateTimeOffset? LastActive { get; set; }
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();

    public required double Latitude { get; set; }
    public required double Longitude { get; set; }
}
