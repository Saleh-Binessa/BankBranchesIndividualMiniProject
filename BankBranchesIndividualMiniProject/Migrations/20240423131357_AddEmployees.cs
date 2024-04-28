using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BankBranchesIndividualMiniProject.Migrations
{
    /// <inheritdoc />
    public partial class AddEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BankBranches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    BranchManager = table.Column<string>(type: "TEXT", nullable: false),
                    EmployeeCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankBranches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    CivilId = table.Column<string>(type: "TEXT", nullable: false),
                    Position = table.Column<string>(type: "TEXT", nullable: false),
                    WorkplaceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_BankBranches_WorkplaceId",
                        column: x => x.WorkplaceId,
                        principalTable: "BankBranches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BankBranches",
                columns: new[] { "BranchId", "BranchManager", "EmployeeCount", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Omar Ali", 35, "https://maps.app.goo.gl/3LTYnjuK7YzeyAD46", "Head office" },
                    { 2, "Majid Al-Shuwaiee", 12, "https://maps.app.goo.gl/3hvBso457K9ZrReNA", "Avenues" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "CivilId", "Name", "Position", "WorkplaceId" },
                values: new object[,]
                {
                    { 1, "299022600558", "Saleh", "DP1", 1 },
                    { 2, "299072600558", "Ahmad", "DP2", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkplaceId",
                table: "Employees",
                column: "WorkplaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "BankBranches");
        }
    }
}
