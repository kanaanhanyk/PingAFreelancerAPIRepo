using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PingAFreelancerInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    DateRegistered = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    TotalSpent = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    HoursBilled = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    InteractionCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RatingSum = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    LastActive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AvatarColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Domains",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domains", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhotoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expertises_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Freelancers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: true),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    ExpertiseId = table.Column<int>(type: "int", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    HoursBilled = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    TotalEarned = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0m),
                    InteractionCount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    RatingSum = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateRegistered = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    PhotoPath = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    AvatarColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastActive = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Freelancers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Freelancers_Domains_DomainId",
                        column: x => x.DomainId,
                        principalTable: "Domains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Freelancers_Expertises_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalTable: "Expertises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FreelancerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: true),
                    HoursContracted = table.Column<int>(type: "int", nullable: true),
                    AmountPaid = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DatePinged = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false, defaultValueSql: "SYSDATETIMEOFFSET()"),
                    DateMatched = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateContracted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    DateFulfilled = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    ProposalMessage = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Review = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Contracts_Freelancers_FreelancerId",
                        column: x => x.FreelancerId,
                        principalTable: "Freelancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Email",
                table: "Clients",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ClientId",
                table: "Contracts",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_FreelancerId",
                table: "Contracts",
                column: "FreelancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Expertises_DomainId",
                table: "Expertises",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_DomainId",
                table: "Freelancers",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_Email",
                table: "Freelancers",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Freelancers_ExpertiseId",
                table: "Freelancers",
                column: "ExpertiseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Freelancers");

            migrationBuilder.DropTable(
                name: "Expertises");

            migrationBuilder.DropTable(
                name: "Domains");
        }
    }
}
