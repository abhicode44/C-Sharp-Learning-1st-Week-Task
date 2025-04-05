using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangesInContactTableCloumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Contact");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Contact",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
