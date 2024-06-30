using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalOwners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalOwners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimalSponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceOfFunding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartOfSponsoring = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    zooUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalSponsors_AnimalOwners_zooUserId",
                        column: x => x.zooUserId,
                        principalTable: "AnimalOwners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalSponsors_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AnimalOwners",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Login", "Password", "PhoneNumber", "Role" },
                values: new object[,]
                {
                    { 1, "admin@domain.com", "admin", "admin", "admin", "$2a$11$fLzRFx6ccBoVg66krYDs2uldQp7zvCvCMZHQLzWFS3FWhz5pdfmdy", "111222333", "Admin" },
                    { 2, "kajetan.stach@wp.pl", "Kajetan", "Stach", "Kajetan25", "$2a$11$6axIcIC9fF52/CaUQT3hE.vDb9fdblLwxp34KHl1ubbiLCNCqKSce", "123456789", "User" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSponsors_AnimalId",
                table: "AnimalSponsors",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSponsors_zooUserId",
                table: "AnimalSponsors",
                column: "zooUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalSponsors");

            migrationBuilder.DropTable(
                name: "AnimalOwners");

            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
