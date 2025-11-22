using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenQuest.AI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Șterge toate tabelele Identity dacă există
            migrationBuilder.Sql(@"
                IF OBJECT_ID('AspNetUserRoles', 'U') IS NOT NULL DROP TABLE AspNetUserRoles;
                IF OBJECT_ID('AspNetUserClaims', 'U') IS NOT NULL DROP TABLE AspNetUserClaims;
                IF OBJECT_ID('AspNetUserLogins', 'U') IS NOT NULL DROP TABLE AspNetUserLogins;
                IF OBJECT_ID('AspNetUserTokens', 'U') IS NOT NULL DROP TABLE AspNetUserTokens;
                IF OBJECT_ID('AspNetRoleClaims', 'U') IS NOT NULL DROP TABLE AspNetRoleClaims;
                IF OBJECT_ID('AspNetRoles', 'U') IS NOT NULL DROP TABLE AspNetRoles;
                IF OBJECT_ID('AspNetUsers', 'U') IS NOT NULL DROP TABLE AspNetUsers;
                IF OBJECT_ID('__EFMigrationsHistory', 'U') IS NOT NULL DELETE FROM __EFMigrationsHistory;
            ");

            // Șterge tabelul Events dacă există
            migrationBuilder.DropTable(
                name: "Events");

            // Creează tabelul Events
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
