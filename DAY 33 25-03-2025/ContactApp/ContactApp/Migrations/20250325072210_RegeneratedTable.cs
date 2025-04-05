using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactApp.Migrations
{
    /// <inheritdoc />
    public partial class RegeneratedTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    Contact_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    L_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.Contact_Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    F_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    L_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_ID);
                });

            migrationBuilder.CreateTable(
                name: "Contact_Details",
                columns: table => new
                {
                    Contact_Details_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Values = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contact_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact_Details", x => x.Contact_Details_Id);
                    table.ForeignKey(
                        name: "FK_Contact_Details_Contact_Contact_Id",
                        column: x => x.Contact_Id,
                        principalTable: "Contact",
                        principalColumn: "Contact_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_Details_Contact_Id",
                table: "Contact_Details",
                column: "Contact_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact_Details");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
