using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEU_Backend.Migrations
{
    /// <inheritdoc />
    public partial class checklistmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationTypeChecklistTasks");

            migrationBuilder.DropTable(
                name: "OperationTypeChecklists");

            migrationBuilder.CreateTable(
                name: "Checklist",
                columns: table => new
                {
                    ChecklistId = table.Column<string>(type: "TEXT", nullable: false),
                    OperationTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checklist", x => x.ChecklistId);
                    table.ForeignKey(
                        name: "FK_Checklist_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Checklist_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "OperationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChecklistTask",
                columns: table => new
                {
                    ChecklistTaskId = table.Column<string>(type: "TEXT", nullable: false),
                    ChecklistId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsCompleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChecklistTask", x => x.ChecklistTaskId);
                    table.ForeignKey(
                        name: "FK_ChecklistTask_Checklist_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklist",
                        principalColumn: "ChecklistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationChecklist",
                columns: table => new
                {
                    OperationId = table.Column<string>(type: "TEXT", nullable: false),
                    ChecklistId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationChecklist", x => new { x.ChecklistId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_OperationChecklist_Checklist_ChecklistId",
                        column: x => x.ChecklistId,
                        principalTable: "Checklist",
                        principalColumn: "ChecklistId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationChecklist_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_DepartmentId",
                table: "Checklist",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Checklist_OperationTypeId",
                table: "Checklist",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ChecklistTask_ChecklistId",
                table: "ChecklistTask",
                column: "ChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationChecklist_OperationId",
                table: "OperationChecklist",
                column: "OperationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChecklistTask");

            migrationBuilder.DropTable(
                name: "OperationChecklist");

            migrationBuilder.DropTable(
                name: "Checklist");

            migrationBuilder.CreateTable(
                name: "OperationTypeChecklists",
                columns: table => new
                {
                    OperationTypeChecklistId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationTypeId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypeChecklists", x => x.OperationTypeChecklistId);
                    table.ForeignKey(
                        name: "FK_OperationTypeChecklists_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationTypeChecklists_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "OperationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationTypeChecklistTasks",
                columns: table => new
                {
                    OperationTypeChecklistTaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OperationTypeChecklistId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    DoneDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypeChecklistTasks", x => x.OperationTypeChecklistTaskId);
                    table.ForeignKey(
                        name: "FK_OperationTypeChecklistTasks_OperationTypeChecklists_OperationTypeChecklistId",
                        column: x => x.OperationTypeChecklistId,
                        principalTable: "OperationTypeChecklists",
                        principalColumn: "OperationTypeChecklistId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperationTypeChecklistTasks_OperationTypeChecklistId",
                table: "OperationTypeChecklistTasks",
                column: "OperationTypeChecklistId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationTypeChecklists_DepartmentId",
                table: "OperationTypeChecklists",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationTypeChecklists_OperationTypeId",
                table: "OperationTypeChecklists",
                column: "OperationTypeId");
        }
    }
}
