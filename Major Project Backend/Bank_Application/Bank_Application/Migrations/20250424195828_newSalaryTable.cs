using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bank_Application.Migrations
{
    /// <inheritdoc />
    public partial class newSalaryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalaryDistributions",
                columns: table => new
                {
                    SalaryDisbutionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmpSalary = table.Column<int>(type: "int", nullable: false),
                    SalaryTransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SalaryDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsSalaryCredit = table.Column<bool>(type: "bit", nullable: false),
                    CompanyEmail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDistributions", x => x.SalaryDisbutionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryDistributions");
        }
    }
}
