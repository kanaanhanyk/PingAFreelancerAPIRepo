using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PingAFreelancerApplication.Entities;

public class ClientProfile
{
    public string Id { get; set; }
    public virtual UserProfile User { get; set; }

    public Persona Persona { get; set; } = Persona.Client;
    public ICollection<Ping> SentPings { get; set; } = new List<Ping>();
}
