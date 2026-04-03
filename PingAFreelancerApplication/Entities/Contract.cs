using System;
using System.Collections.Generic;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class Contract
{
    public string Id { get; set; }

    public string ClientId { get; set; }
    public ClientProfile Client { get; set; }

    public string FreelancerId { get; set; }
    public FreelancerProfile Freelancer { get; set; }
    public int? Rating { get; set; }
    public int? HoursContracted { get; set; }
    public int? AmountPaid { get; set; }
    public DateTime DatePinged { get; set; }
    public DateTime? DateStarted { get; set; }
    public DateTime? DateCompleted { get; set; }
    public string Message { get; set; }
}
