using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DB1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Animals_AspNetUsers_ZooUserId",
                table: "Animals");

            migrationBuilder.DropIndex(
                name: "IX_Animals_ZooUserId",
                table: "Animals");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "83247002-78fa-430a-ac17-fb1c4b93dc44");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c096a95c-3fd7-4cbc-9e56-7d4f36d03919", "b9078b46-5beb-4335-96f3-47e8fc3e25f3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c096a95c-3fd7-4cbc-9e56-7d4f36d03919");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "b9078b46-5beb-4335-96f3-47e8fc3e25f3");

            migrationBuilder.DropColumn(
                name: "ZooUserId",
                table: "Animals");

            migrationBuilder.CreateTable(
                name: "AnimalSponsors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PriceOfFunding = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartOfSponsoring = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalSponsors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalSponsors_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalSponsors_AspNetUsers_UserName",
                        column: x => x.UserName,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d45fa521-0229-4879-b653-f977d63c1112", "d45fa521-0229-4879-b653-f977d63c1112", "employee", "EMPLOYEE" },
                    { "fd479d40-e642-4642-be22-3fff0436f7e3", "fd479d40-e642-4642-be22-3fff0436f7e3", "adminRole", "ADMINROLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "6c6296bb-953f-4fec-b279-6ef57c1fbd22", 0, "428cdab7-6286-4f4f-8d6b-de15af1fc9ee", "admin@wp.pl", true, "admin", "admin", false, null, "ADMIN@WP.PL", "ADMIN", "AQAAAAIAAYagAAAAEBeiZrKT89THKKUkJ4VIgLhSzxyElQ5X18doEpZEdOyyXZqtinf9JY2FL9GA3RRvpw==", null, false, "636fc7bf-855c-4e46-930e-26c3eae695d5", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fd479d40-e642-4642-be22-3fff0436f7e3", "6c6296bb-953f-4fec-b279-6ef57c1fbd22" });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSponsors_AnimalId",
                table: "AnimalSponsors",
                column: "AnimalId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSponsors_UserName",
                table: "AnimalSponsors",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalSponsors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d45fa521-0229-4879-b653-f977d63c1112");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fd479d40-e642-4642-be22-3fff0436f7e3", "6c6296bb-953f-4fec-b279-6ef57c1fbd22" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd479d40-e642-4642-be22-3fff0436f7e3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c6296bb-953f-4fec-b279-6ef57c1fbd22");

            migrationBuilder.AddColumn<string>(
                name: "ZooUserId",
                table: "Animals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "83247002-78fa-430a-ac17-fb1c4b93dc44", "83247002-78fa-430a-ac17-fb1c4b93dc44", "employee", "EMPLOYEE" },
                    { "c096a95c-3fd7-4cbc-9e56-7d4f36d03919", "c096a95c-3fd7-4cbc-9e56-7d4f36d03919", "adminRole", "ADMINROLE" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b9078b46-5beb-4335-96f3-47e8fc3e25f3", 0, "758980eb-6ce9-499e-89a9-44b5f9fc9656", "admin@wp.pl", true, "admin", "admin", false, null, "ADMIN@WP.PL", "ADMIN", "AQAAAAIAAYagAAAAEAmG7vnHYorBbKPcYMLt4syqIOhA12uctHY6IspW6DTMjslUU3e81oH5tk40xrNY2w==", null, false, "4f9fbb52-dd21-43fe-81b4-5aa808b2f7ee", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c096a95c-3fd7-4cbc-9e56-7d4f36d03919", "b9078b46-5beb-4335-96f3-47e8fc3e25f3" });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_ZooUserId",
                table: "Animals",
                column: "ZooUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Animals_AspNetUsers_ZooUserId",
                table: "Animals",
                column: "ZooUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
