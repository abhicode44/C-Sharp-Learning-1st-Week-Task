using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Application.Migrations
{
    /// <inheritdoc />
    public partial class updatecompanytable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Roles_RoleId",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Companies_RoleId",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "CompanyBalance",
                table: "Companies");

            migrationBuilder.AddColumn<string>(
                name: "CompanyPassword",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompanyPassword",
                table: "Companies");

            migrationBuilder.AddColumn<int>(
                name: "CompanyBalance",
                table: "Companies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Companies_RoleId",
                table: "Companies",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Roles_RoleId",
                table: "Companies",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
