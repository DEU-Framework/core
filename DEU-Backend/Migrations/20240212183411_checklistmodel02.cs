using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEU_Backend.Migrations
{
    /// <inheritdoc />
    public partial class checklistmodel02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Checklist_Departments_DepartmentId",
                table: "Checklist");

            migrationBuilder.DropForeignKey(
                name: "FK_Checklist_OperationTypes_OperationTypeId",
                table: "Checklist");

            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistTask_Checklist_ChecklistId",
                table: "ChecklistTask");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationChecklist_Checklist_ChecklistId",
                table: "OperationChecklist");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationChecklist_Operations_OperationId",
                table: "OperationChecklist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationChecklist",
                table: "OperationChecklist");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChecklistTask",
                table: "ChecklistTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklist",
                table: "Checklist");

            migrationBuilder.RenameTable(
                name: "OperationChecklist",
                newName: "OperationChecklists");

            migrationBuilder.RenameTable(
                name: "ChecklistTask",
                newName: "ChecklistTasks");

            migrationBuilder.RenameTable(
                name: "Checklist",
                newName: "Checklists");

            migrationBuilder.RenameIndex(
                name: "IX_OperationChecklist_OperationId",
                table: "OperationChecklists",
                newName: "IX_OperationChecklists_OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistTask_ChecklistId",
                table: "ChecklistTasks",
                newName: "IX_ChecklistTasks_ChecklistId");

            migrationBuilder.RenameIndex(
                name: "IX_Checklist_OperationTypeId",
                table: "Checklists",
                newName: "IX_Checklists_OperationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Checklist_DepartmentId",
                table: "Checklists",
                newName: "IX_Checklists_DepartmentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationChecklists",
                table: "OperationChecklists",
                columns: new[] { "ChecklistId", "OperationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChecklistTasks",
                table: "ChecklistTasks",
                column: "ChecklistTaskId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists",
                column: "ChecklistId");

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistTasks_Checklists_ChecklistId",
                table: "ChecklistTasks",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "ChecklistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_Departments_DepartmentId",
                table: "Checklists",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checklists_OperationTypes_OperationTypeId",
                table: "Checklists",
                column: "OperationTypeId",
                principalTable: "OperationTypes",
                principalColumn: "OperationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChecklists_Checklists_ChecklistId",
                table: "OperationChecklists",
                column: "ChecklistId",
                principalTable: "Checklists",
                principalColumn: "ChecklistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChecklists_Operations_OperationId",
                table: "OperationChecklists",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChecklistTasks_Checklists_ChecklistId",
                table: "ChecklistTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_Departments_DepartmentId",
                table: "Checklists");

            migrationBuilder.DropForeignKey(
                name: "FK_Checklists_OperationTypes_OperationTypeId",
                table: "Checklists");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationChecklists_Checklists_ChecklistId",
                table: "OperationChecklists");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationChecklists_Operations_OperationId",
                table: "OperationChecklists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OperationChecklists",
                table: "OperationChecklists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Checklists",
                table: "Checklists");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChecklistTasks",
                table: "ChecklistTasks");

            migrationBuilder.RenameTable(
                name: "OperationChecklists",
                newName: "OperationChecklist");

            migrationBuilder.RenameTable(
                name: "Checklists",
                newName: "Checklist");

            migrationBuilder.RenameTable(
                name: "ChecklistTasks",
                newName: "ChecklistTask");

            migrationBuilder.RenameIndex(
                name: "IX_OperationChecklists_OperationId",
                table: "OperationChecklist",
                newName: "IX_OperationChecklist_OperationId");

            migrationBuilder.RenameIndex(
                name: "IX_Checklists_OperationTypeId",
                table: "Checklist",
                newName: "IX_Checklist_OperationTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Checklists_DepartmentId",
                table: "Checklist",
                newName: "IX_Checklist_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_ChecklistTasks_ChecklistId",
                table: "ChecklistTask",
                newName: "IX_ChecklistTask_ChecklistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OperationChecklist",
                table: "OperationChecklist",
                columns: new[] { "ChecklistId", "OperationId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Checklist",
                table: "Checklist",
                column: "ChecklistId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChecklistTask",
                table: "ChecklistTask",
                column: "ChecklistTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Checklist_Departments_DepartmentId",
                table: "Checklist",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Checklist_OperationTypes_OperationTypeId",
                table: "Checklist",
                column: "OperationTypeId",
                principalTable: "OperationTypes",
                principalColumn: "OperationTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChecklistTask_Checklist_ChecklistId",
                table: "ChecklistTask",
                column: "ChecklistId",
                principalTable: "Checklist",
                principalColumn: "ChecklistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChecklist_Checklist_ChecklistId",
                table: "OperationChecklist",
                column: "ChecklistId",
                principalTable: "Checklist",
                principalColumn: "ChecklistId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OperationChecklist_Operations_OperationId",
                table: "OperationChecklist",
                column: "OperationId",
                principalTable: "Operations",
                principalColumn: "OperationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
