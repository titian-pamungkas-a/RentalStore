using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalStore.Migrations
{
    /// <inheritdoc />
    public partial class addGenderEnum3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:gender_type_is", "male,female")
                .OldAnnotation("Npgsql:Enum:gender_type", "male,female");

            migrationBuilder.AlterColumn<int>(
                name: "gender_user",
                table: "users",
                type: "gender_type_is",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "gender_user");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "genres",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "genres");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:Enum:gender_type", "male,female")
                .OldAnnotation("Npgsql:Enum:gender_type_is", "male,female");

            migrationBuilder.AlterColumn<int>(
                name: "gender_user",
                table: "users",
                type: "gender_user",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "gender_type_is");
        }
    }
}
