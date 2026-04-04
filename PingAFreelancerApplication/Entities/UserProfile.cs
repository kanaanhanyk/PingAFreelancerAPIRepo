using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class UserProfile
{
    public string Id { get; set; } = string.Empty;

    
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public DateTime DateRegistered { get; set; }
    public string PhotoPath { get; set; } = string.Empty;
    public bool IsActive { get; set; }
    public Persona Persona { get; set; }
}