using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FocusDesk.API.Migrations
{
    /// <inheritdoc />
    public partial class AddStudieDoelIdToStudiesessie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BestedeUren",
                table: "StudieDoelen",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BestedeUren",
                table: "StudieDoelen");
        }
    }
}
