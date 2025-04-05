using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Migrations
{
    /// <inheritdoc />
    public partial class ADDCLOUMNTOCONTACTTABLE : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_ID",
                table: "Contact",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contact_User_ID",
                table: "Contact",
                column: "User_ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_User_User_ID",
                table: "Contact",
                column: "User_ID",
                principalTable: "User",
                principalColumn: "User_ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_User_User_ID",
                table: "Contact");

            migrationBuilder.DropIndex(
                name: "IX_Contact_User_ID",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "User_ID",
                table: "Contact");
        }
    }
}
