using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Application.Migrations
{
    /// <inheritdoc />
    public partial class tablesadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AdminUserName",
                table: "Admin",
                newName: "AdminLastName");

            migrationBuilder.AddColumn<string>(
                name: "AdminEmail",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AdminFirstName",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdminActive",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminEmail",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "AdminFirstName",
                table: "Admin");

            migrationBuilder.DropColumn(
                name: "IsAdminActive",
                table: "Admin");

            migrationBuilder.RenameColumn(
                name: "AdminLastName",
                table: "Admin",
                newName: "AdminUserName");
        }
    }
}
