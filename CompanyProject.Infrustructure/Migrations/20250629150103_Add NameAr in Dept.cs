using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNameArinDept : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "departments",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "departments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "departments");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "departments",
                newName: "Name");
        }
    }
}
