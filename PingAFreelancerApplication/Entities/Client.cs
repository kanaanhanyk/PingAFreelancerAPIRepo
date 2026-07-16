using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class Client
{
    public Guid Id { get; set; }

    public string DisplayName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public DateTimeOffset DateRegistered { get; set; } 
    public decimal TotalSpent { get; set; }
    public decimal HoursBilled { get; set; }
    public bool IsActive { get; set; }
    public int InteractionCount { get; set; }
    public decimal RatingSum { get; set; }

    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();

}
