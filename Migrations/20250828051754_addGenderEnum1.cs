using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalStore.Migrations
{
    /// <inheritdoc />
    public partial class addGenderEnum1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenderUser",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "gender_user",
                table: "users",
                type: "gender_user",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender_user",
                table: "users");

            migrationBuilder.AddColumn<int>(
                name: "GenderUser",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
