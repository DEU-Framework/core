using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEU_Backend.Migrations
{
    /// <inheritdoc />
    public partial class contacts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationSubTypes_SubTypeId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationTypes_TypeId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_SubTypeId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_TypeId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "SubTypeId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "TypeId",
                table: "Operations");

            migrationBuilder.AddColumn<string>(
                name: "OperationSubTypeId",
                table: "Operations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OperationTypeId",
                table: "Operations",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OperationTypeHistory",
                columns: table => new
                {
                    OperationTypeHistoryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    OperationId = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<string>(type: "TEXT", nullable: false),
                    TypeId = table.Column<string>(type: "TEXT", nullable: false),
                    SubTypeId = table.Column<string>(type: "TEXT", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypeHistory", x => x.OperationTypeHistoryId);
                    table.ForeignKey(
                        name: "FK_OperationTypeHistory_OperationSubTypes_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "OperationSubTypes",
                        principalColumn: "OperationSubTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationTypeHistory_OperationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "OperationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationTypeHistory_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationSubTypeId",
                table: "Operations",
                column: "OperationSubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_OperationTypeId",
                table: "Operations",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationTypeHistory_OperationId",
                table: "OperationTypeHistory",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationTypeHistory_SubTypeId",
                table: "OperationTypeHistory",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationTypeHistory_TypeId",
                table: "OperationTypeHistory",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationSubTypes_OperationSubTypeId",
                table: "Operations",
                column: "OperationSubTypeId",
                principalTable: "OperationSubTypes",
                principalColumn: "OperationSubTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationTypes_OperationTypeId",
                table: "Operations",
                column: "OperationTypeId",
                principalTable: "OperationTypes",
                principalColumn: "OperationTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationSubTypes_OperationSubTypeId",
                table: "Operations");

            migrationBuilder.DropForeignKey(
                name: "FK_Operations_OperationTypes_OperationTypeId",
                table: "Operations");

            migrationBuilder.DropTable(
                name: "OperationTypeHistory");

            migrationBuilder.DropIndex(
                name: "IX_Operations_OperationSubTypeId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_OperationTypeId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "OperationSubTypeId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "OperationTypeId",
                table: "Operations");

            migrationBuilder.AddColumn<string>(
                name: "SubTypeId",
                table: "Operations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TypeId",
                table: "Operations",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_SubTypeId",
                table: "Operations",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_TypeId",
                table: "Operations",
                column: "TypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationSubTypes_SubTypeId",
                table: "Operations",
                column: "SubTypeId",
                principalTable: "OperationSubTypes",
                principalColumn: "OperationSubTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_OperationTypes_TypeId",
                table: "Operations",
                column: "TypeId",
                principalTable: "OperationTypes",
                principalColumn: "OperationTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
