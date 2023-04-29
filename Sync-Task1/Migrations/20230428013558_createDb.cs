using Microsoft.EntityFrameworkCore.Migrations;

namespace Sync_Task1.Migrations
{
    public partial class createDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "developer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    imgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_developer", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "solution",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    timeInHours = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_solution", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bug",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    state = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priority = table.Column<int>(type: "int", nullable: false),
                    solutionid = table.Column<int>(type: "int", nullable: true),
                    developerid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bug", x => x.id);
                    table.ForeignKey(
                        name: "FK_bug_developer_developerid",
                        column: x => x.developerid,
                        principalTable: "developer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bug_solution_solutionid",
                        column: x => x.solutionid,
                        principalTable: "solution",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bug_developerid",
                table: "bug",
                column: "developerid");

            migrationBuilder.CreateIndex(
                name: "IX_bug_solutionid",
                table: "bug",
                column: "solutionid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bug");

            migrationBuilder.DropTable(
                name: "developer");

            migrationBuilder.DropTable(
                name: "solution");
        }
    }
}
