using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerCore.Entities;

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
    public DateTimeOffset? DateMatched { get; set; }
    public DateTimeOffset? DateContracted { get; set; }
    public DateTimeOffset? DateFulfilled { get; set; }
    public string? ProposalMessage { get; set; }
    public string? Review { get; set; }
    public ContractStatus Status { get; set; }
}
