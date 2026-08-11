using PingAFreelancerCore.Entities;
using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Clients;

public static class ContractMappings
{
    public static ClientResponse MapToClientResponse(this Client client)
    {
        return new ClientResponse(
            client.Id,
            client.FirstName,
            client.LastName,
            client.Email,
            client.PhoneNumber,
            client.DateRegistered,
            client.TotalSpent,
            client.HoursBilled,
            client.InteractionCount,
            client.RatingSum,
            client.LastActive,
            client.AvatarColor
        );
    }

    public static ClientsResponse MapToClientsResponse(this List<Client> clients)
    {
        return new ClientsResponse(
            clients.Select(c => c.MapToClientResponse()).ToList()
        );
    }
}
