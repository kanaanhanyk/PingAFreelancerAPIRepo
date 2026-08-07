using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PingAFreelancerInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Domains",
                columns: new[] { "Id", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { -5, "Tech", "tech.png" },
                    { -4, "Lifestyle", "lifestyle.png" },
                    { -3, "Health", "health.png" },
                    { -2, "Domestic", "domestic.png" },
                    { -1, "Labor", "labor.png" }
                });

            migrationBuilder.InsertData(
                table: "Expertises",
                columns: new[] { "Id", "DomainId", "Name", "PhotoPath" },
                values: new object[,]
                {
                    { -38, -5, "Wifi Guy", "wifi_guy.png" },
                    { -37, -5, "Smart Home Guy", "smart_home_guy.png" },
                    { -36, -5, "Security Camera Guy", "security_camera_guy.png" },
                    { -35, -5, "Appliance Guy", "appliance_guy.png" },
                    { -34, -4, "Tutor", "tutor.png" },
                    { -33, -4, "Stylist", "stylist.png" },
                    { -32, -4, "Photographer", "photographer.png" },
                    { -31, -4, "Music Teacher", "music_teacher.png" },
                    { -30, -4, "Interior Designer", "interior_designer.png" },
                    { -29, -4, "Image Consultant", "image_consultant.png" },
                    { -28, -4, "Dance Instructor", "dance_instructor.png" },
                    { -27, -3, "Yoga Instructor", "yoga_instructor.png" },
                    { -26, -3, "Physiotherapist", "physiotherapist.png" },
                    { -25, -3, "Personal Trainer", "personal_trainer.png" },
                    { -24, -3, "Health Aide", "health_aide.png" },
                    { -23, -3, "Elderly Companion", "elderly_companion.png" },
                    { -22, -3, "Chiropractor", "chiropractor.png" },
                    { -21, -2, "Nanny", "nanny.png" },
                    { -20, -2, "Kitchen Cleaner", "kitchen_cleaner.png" },
                    { -19, -2, "Housesitter", "housesitter.png" },
                    { -18, -2, "Housekeeper", "housekeeper.png" },
                    { -17, -2, "Grocery Shopper", "grocery_shopper.png" },
                    { -16, -2, "Gardener", "gardener.png" },
                    { -15, -2, "Errand Runner", "errand_runner.png" },
                    { -14, -2, "Cook", "cook.png" },
                    { -13, -2, "Caregiver", "caregiver.png" },
                    { -12, -2, "Bartender", "bartender.png" },
                    { -11, -2, "Babysitter", "babysitter.png" },
                    { -10, -1, "Yard Worker", "yard_worker.png" },
                    { -9, -1, "Window Cleaner", "window_cleaner.png" },
                    { -8, -1, "Roof Repairer", "roof_repairer.png" },
                    { -7, -1, "Plumber", "plumber.png" },
                    { -6, -1, "Painter", "painter.png" },
                    { -5, -1, "Packing Service", "packing_service.png" },
                    { -4, -1, "Furniture Assembler", "furniture_assembler.png" },
                    { -3, -1, "Electrician", "electrician.png" },
                    { -2, -1, "Chauffeur", "chauffeur.png" },
                    { -1, -1, "Carpenter", "carpenter.png" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -38);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -37);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -36);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -35);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -34);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -33);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -32);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -31);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -30);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -29);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -28);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -27);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -26);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -25);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Expertises",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: -4);

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Domains",
                keyColumn: "Id",
                keyValue: -1);
        }
    }
}
