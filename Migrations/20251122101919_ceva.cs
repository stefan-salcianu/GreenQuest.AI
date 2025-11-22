using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GreenQuest.AI.Migrations
{
    /// <inheritdoc />
    public partial class ceva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "AspNetRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "AspNetRoles");
        }
    }
}
