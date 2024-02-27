using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEU_Backend.Migrations
{
    /// <inheritdoc />
    public partial class contactandalarmplan : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrewCount",
                table: "Vehicles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "DepartmentName",
                table: "OperationActions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "OperationActions",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompletedBy",
                table: "ChecklistTasks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Alarmplan",
                columns: table => new
                {
                    AlarmplanId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OperationTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    ZoneId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alarmplan", x => x.AlarmplanId);
                    table.ForeignKey(
                        name: "FK_Alarmplan_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Alarmplan_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "OperationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallOutOrder",
                columns: table => new
                {
                    OperationTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallOutOrder", x => new { x.OperationTypeId, x.DepartmentId });
                    table.ForeignKey(
                        name: "FK_CallOutOrder_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallOutOrder_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "OperationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Infos = table.Column<string>(type: "TEXT", nullable: true),
                    SirenCode = table.Column<string>(type: "TEXT", nullable: true),
                    IsSpecialDepartment = table.Column<bool>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                    table.ForeignKey(
                        name: "FK_Contact_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlarmplanEntry",
                columns: table => new
                {
                    AlarmplanEntryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    AlarmplanId = table.Column<Guid>(type: "TEXT", nullable: false),
                    VehicleName = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlarmplanEntry", x => x.AlarmplanEntryId);
                    table.ForeignKey(
                        name: "FK_AlarmplanEntry_Alarmplan_AlarmplanId",
                        column: x => x.AlarmplanId,
                        principalTable: "Alarmplan",
                        principalColumn: "AlarmplanId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CallOutOrderVehicle",
                columns: table => new
                {
                    VehiclesVehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    CallOutOrdersOperationTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    CallOutOrdersDepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallOutOrderVehicle", x => new { x.VehiclesVehicleId, x.CallOutOrdersOperationTypeId, x.CallOutOrdersDepartmentId });
                    table.ForeignKey(
                        name: "FK_CallOutOrderVehicle_CallOutOrder_CallOutOrdersOperationTypeId_CallOutOrdersDepartmentId",
                        columns: x => new { x.CallOutOrdersOperationTypeId, x.CallOutOrdersDepartmentId },
                        principalTable: "CallOutOrder",
                        principalColumns: new[] { "OperationTypeId", "DepartmentId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CallOutOrderVehicle_Vehicles_VehiclesVehicleId",
                        column: x => x.VehiclesVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alarmplan_DepartmentId",
                table: "Alarmplan",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Alarmplan_OperationTypeId",
                table: "Alarmplan",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AlarmplanEntry_AlarmplanId",
                table: "AlarmplanEntry",
                column: "AlarmplanId");

            migrationBuilder.CreateIndex(
                name: "IX_CallOutOrder_DepartmentId",
                table: "CallOutOrder",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CallOutOrderVehicle_CallOutOrdersOperationTypeId_CallOutOrdersDepartmentId",
                table: "CallOutOrderVehicle",
                columns: new[] { "CallOutOrdersOperationTypeId", "CallOutOrdersDepartmentId" });

            migrationBuilder.CreateIndex(
                name: "IX_Contact_DepartmentId",
                table: "Contact",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlarmplanEntry");

            migrationBuilder.DropTable(
                name: "CallOutOrderVehicle");

            migrationBuilder.DropTable(
                name: "Contact");

            migrationBuilder.DropTable(
                name: "Alarmplan");

            migrationBuilder.DropTable(
                name: "CallOutOrder");

            migrationBuilder.DropColumn(
                name: "CrewCount",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DepartmentName",
                table: "OperationActions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "OperationActions");

            migrationBuilder.DropColumn(
                name: "CompletedBy",
                table: "ChecklistTasks");
        }
    }
}
