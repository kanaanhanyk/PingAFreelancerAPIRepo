using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PingAFreelancerCore.Entities;

namespace PingAFreelancerInfrastructure.Data.Configurations;

public class ExpertiseConfiguration : IEntityTypeConfiguration<Expertise>
{
    public void Configure(EntityTypeBuilder<Expertise> entity)
    {
        entity.HasKey(e => e.Id);

        entity.Property(e => e.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();
            
        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.PhotoPath)
            .IsRequired()
            .HasMaxLength(255);

        entity.HasOne(e => e.Domain)
            .WithMany(d => d.Expertises)
            .HasForeignKey(e => e.DomainId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasMany(e => e.Freelancers)
            .WithOne(f => f.Expertise)
            .HasForeignKey(f => f.ExpertiseId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasData(
            new Expertise
            {
                Id = -1,
                Name = "Carpenter",
                PhotoPath = "carpenter.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -2,
                Name = "Chauffeur",
                PhotoPath = "chauffeur.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -3,
                Name = "Electrician",
                PhotoPath = "electrician.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -4,
                Name = "Furniture Assembler",
                PhotoPath = "furniture_assembler.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -5,
                Name = "Packing Service",
                PhotoPath = "packing_service.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -6,
                Name = "Painter",
                PhotoPath = "painter.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -7,
                Name = "Plumber",
                PhotoPath = "plumber.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -8,
                Name = "Roof Repairer",
                PhotoPath = "roof_repairer.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -9,
                Name = "Window Cleaner",
                PhotoPath = "window_cleaner.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -10,
                Name = "Yard Worker",
                PhotoPath = "yard_worker.png",
                DomainId = -1,
            },
            new Expertise
            {
                Id = -11,
                Name = "Babysitter",
                PhotoPath = "babysitter.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -12,
                Name = "Bartender",
                PhotoPath = "bartender.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -13,
                Name = "Caregiver",
                PhotoPath = "caregiver.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -14,
                Name = "Cook",
                PhotoPath = "cook.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -15,
                Name = "Errand Runner",
                PhotoPath = "errand_runner.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -16,
                Name = "Gardener",
                PhotoPath = "gardener.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -17,
                Name = "Grocery Shopper",
                PhotoPath = "grocery_shopper.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -18,
                Name = "Housekeeper",
                PhotoPath = "housekeeper.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -19,
                Name = "Housesitter",
                PhotoPath = "housesitter.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -20,
                Name = "Kitchen Cleaner",
                PhotoPath = "kitchen_cleaner.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -21,
                Name = "Nanny",
                PhotoPath = "nanny.png",
                DomainId = -2,
            },
            new Expertise
            {
                Id = -22,
                Name = "Chiropractor",
                PhotoPath = "chiropractor.png",
                DomainId = -3,
            },
            new Expertise
            {
                Id = -23,
                Name = "Elderly Companion",
                PhotoPath = "elderly_companion.png",
                DomainId = -3,
            },
            new Expertise
            {
                Id = -24,
                Name = "Health Aide",
                PhotoPath = "health_aide.png",
                DomainId = -3,
            },
            new Expertise
            {
                Id = -25,
                Name = "Personal Trainer",
                PhotoPath = "personal_trainer.png",
                DomainId = -3,
            },
            new Expertise
            {
                Id = -26,
                Name = "Physiotherapist",
                PhotoPath = "physiotherapist.png",
                DomainId = -3,
            },
            new Expertise
            {
                Id = -27,
                Name = "Yoga Instructor",
                PhotoPath = "yoga_instructor.png",
                DomainId = -3,
            },
            new Expertise
            {
                Id = -28,
                Name = "Dance Instructor",
                PhotoPath = "dance_instructor.png",
                DomainId = -4,
            },
            new Expertise
            {
                Id = -29,
                Name = "Image Consultant",
                PhotoPath = "image_consultant.png",
                DomainId = -4,
            },
            new Expertise
            {
                Id = -30,
                Name = "Interior Designer",
                PhotoPath = "interior_designer.png",
                DomainId = -4,
            },
            new Expertise
            {
                Id = -31,
                Name = "Music Teacher",
                PhotoPath = "music_teacher.png",
                DomainId = -4,
            },
            new Expertise
            {
                Id = -32,
                Name = "Photographer",
                PhotoPath = "photographer.png",
                DomainId = -4,
            },
            new Expertise
            {
                Id = -33,
                Name = "Stylist",
                PhotoPath = "stylist.png",
                DomainId = -4,
            },
            new Expertise
            {
                Id = -34,
                Name = "Tutor",
                PhotoPath = "tutor.png",
                DomainId = -4,
            },
            new Expertise
            {
                Id = -35,
                Name = "Appliance Guy",
                PhotoPath = "appliance_guy.png",
                DomainId = -5,
            },
            new Expertise
            {
                Id = -36,
                Name = "Security Camera Guy",
                PhotoPath = "security_camera_guy.png",
                DomainId = -5,
            },
            new Expertise
            {
                Id = -37,
                Name = "Smart Home Guy",
                PhotoPath = "smart_home_guy.png",
                DomainId = -5,
            },
            new Expertise
            {
                Id = -38,
                Name = "Wifi Guy",
                PhotoPath = "wifi_guy.png",
                DomainId = -5,
            }
        );
    }
}
