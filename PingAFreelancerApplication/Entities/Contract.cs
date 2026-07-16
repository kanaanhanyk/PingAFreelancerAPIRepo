using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class Contract
{
    public Guid Id { get; set; }

    public Guid ClientId { get; set; }
    public Client Client { get; set; }

    public Guid FreelancerId { get; set; }
    public Freelancer Freelancer { get; set; }
    
    public int? Rating { get; set; }
    public int? HoursContracted { get; set; }
    public decimal? AmountPaid { get; set; }
    public DateTimeOffset DatePinged { get; set; }
    public DateTimeOffset? DateStarted { get; set; }
    public DateTimeOffset? DateCompleted { get; set; }
    public string Message { get; set; }
    public Status Status { get; set; }
    public bool? IsMatchSeen { get; set; }
    public bool? IsContractedSeen { get; set; }
}
