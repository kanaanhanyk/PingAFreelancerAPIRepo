using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PingAFreelancerCore.Entities;

public class Client
{
    public Guid Id { get; set; }

    public required string FirstName { get; set; }
    public string? LastName { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTimeOffset DateRegistered { get; set; } 
    public decimal TotalSpent { get; set; }
    public int HoursBilled { get; set; }
    public int InteractionCount { get; set; }
    public decimal RatingSum { get; set; }
    public DateTimeOffset? LastActive { get; set; }
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
    public string AvatarColor { get; set; } = "#FFFFFF";
}
