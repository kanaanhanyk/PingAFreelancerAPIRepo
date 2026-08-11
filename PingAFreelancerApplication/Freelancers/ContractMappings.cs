using PingAFreelancerCore.Entities;
using PingAFreelancerContracts;

namespace PingAFreelancerApplication.Freelancers;

public static class ContractMappings
{
    public static FreelancerResponse MapToFreelancerResponse(this Freelancer freelancer)
        {
            return new FreelancerResponse(
                freelancer.Id,
                freelancer.FirstName,
                freelancer.LastName,
                freelancer.Email,
                freelancer.PhoneNumber,
                freelancer.DomainId,
                freelancer.ExpertiseId,
                freelancer.HourlyRate,
                freelancer.HoursBilled,
                freelancer.TotalEarned,
                freelancer.InteractionCount,
                freelancer.RatingSum,
                freelancer.DateRegistered,
                freelancer.PhotoPath,
                freelancer.AvatarColor,
                freelancer.LastActive,
                freelancer.Latitude,
                freelancer.Longitude,
                (PingAFreelancerContracts.Gender)(int)freelancer.Gender
            );
        }

    public static FreelancersResponse MapToFreelancersResponse(this ICollection<Freelancer> freelancers)
    {
        return new FreelancersResponse(freelancers.Select(f => f.MapToFreelancerResponse()).ToList());
    }
}

