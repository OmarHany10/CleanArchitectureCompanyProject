using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CompanyProject.Infrustructure.Migrations
{
    /// <inheritdoc />
    public partial class AddProjectLeadertable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeProjects",
                table: "employeeProjects");

            migrationBuilder.DropIndex(
                name: "IX_employeeProjects_ProjectId",
                table: "employeeProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmentProjects",
                table: "departmentProjects");

            migrationBuilder.DropIndex(
                name: "IX_departmentProjects_ProjectId",
                table: "departmentProjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "employeeProjects");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "departmentProjects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectLeaderId",
                table: "projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LeaderMangerId",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeProjects",
                table: "employeeProjects",
                columns: new[] { "ProjectId", "EmployeeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmentProjects",
                table: "departmentProjects",
                columns: new[] { "ProjectId", "DepartmentId" });

            migrationBuilder.CreateTable(
                name: "ProjectLeader",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SupervisorId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectLeader", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectLeader_ProjectLeader_SupervisorId",
                        column: x => x.SupervisorId,
                        principalTable: "ProjectLeader",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjectLeader_departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_projects_ProjectLeaderId",
                table: "projects",
                column: "ProjectLeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_departments_LeaderMangerId",
                table: "departments",
                column: "LeaderMangerId",
                unique: true,
                filter: "[LeaderMangerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLeader_DepartmentId",
                table: "ProjectLeader",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectLeader_SupervisorId",
                table: "ProjectLeader",
                column: "SupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_ProjectLeader_LeaderMangerId",
                table: "departments",
                column: "LeaderMangerId",
                principalTable: "ProjectLeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_projects_ProjectLeader_ProjectLeaderId",
                table: "projects",
                column: "ProjectLeaderId",
                principalTable: "ProjectLeader",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_ProjectLeader_LeaderMangerId",
                table: "departments");

            migrationBuilder.DropForeignKey(
                name: "FK_projects_ProjectLeader_ProjectLeaderId",
                table: "projects");

            migrationBuilder.DropTable(
                name: "ProjectLeader");

            migrationBuilder.DropIndex(
                name: "IX_projects_ProjectLeaderId",
                table: "projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_employeeProjects",
                table: "employeeProjects");

            migrationBuilder.DropIndex(
                name: "IX_departments_LeaderMangerId",
                table: "departments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmentProjects",
                table: "departmentProjects");

            migrationBuilder.DropColumn(
                name: "ProjectLeaderId",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "LeaderMangerId",
                table: "departments");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "employeeProjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "departmentProjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_employeeProjects",
                table: "employeeProjects",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmentProjects",
                table: "departmentProjects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_employeeProjects_ProjectId",
                table: "employeeProjects",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_departmentProjects_ProjectId",
                table: "departmentProjects",
                column: "ProjectId");
        }
    }
}
