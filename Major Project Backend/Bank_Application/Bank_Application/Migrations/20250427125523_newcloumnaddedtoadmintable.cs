using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Application.Migrations
{
    /// <inheritdoc />
    public partial class newcloumnaddedtoadmintable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminProfilePhoto",
                table: "Admin",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminProfilePhoto",
                table: "Admin");
        }
    }
}
