using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEU_Backend.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    RefreshToken = table.Column<string>(type: "TEXT", nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    Website = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "OperationSubTypes",
                columns: table => new
                {
                    OperationSubTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationSubTypes", x => x.OperationSubTypeId);
                });

            migrationBuilder.CreateTable(
                name: "OperationTypes",
                columns: table => new
                {
                    OperationTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Color = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationTypes", x => x.OperationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserDepartmentRoles",
                columns: table => new
                {
                    UserDepartmentRoleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleName = table.Column<string>(type: "TEXT", nullable: false),
                    RoleDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartmentRoles", x => x.UserDepartmentRoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserDepartmentSkills",
                columns: table => new
                {
                    UserDepartmentSkillId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SkillName = table.Column<string>(type: "TEXT", nullable: false),
                    SkillDescription = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDepartmentSkills", x => x.UserDepartmentSkillId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pois",
                columns: table => new
                {
                    PoiId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pois", x => x.PoiId);
                    table.ForeignKey(
                        name: "FK_Pois_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    CallSign = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WaKaWaterSources",
                columns: table => new
                {
                    WaKaWaterSourceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SourceWaKaWaterSourceId = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    SourceType = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    IconUrl = table.Column<string>(type: "TEXT", nullable: true),
                    IconWidth = table.Column<double>(type: "REAL", nullable: false),
                    IconHeight = table.Column<double>(type: "REAL", nullable: false),
                    IconAnchorX = table.Column<double>(type: "REAL", nullable: false),
                    IconAnchorY = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Capacity = table.Column<int>(type: "INTEGER", nullable: false),
                    Flowrate = table.Column<int>(type: "INTEGER", nullable: false),
                    Connections = table.Column<string>(type: "TEXT", nullable: true),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaKaWaterSources", x => x.WaKaWaterSourceId);
                    table.ForeignKey(
                        name: "FK_WaKaWaterSources_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationTypeChecklists",
                columns: table => new
                {
                    OperationTypeChecklistId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OperationTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
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
                name: "Operations",
                columns: table => new
                {
                    OperationId = table.Column<string>(type: "TEXT", nullable: false),
                    Level = table.Column<string>(type: "TEXT", nullable: false),
                    District = table.Column<string>(type: "TEXT", nullable: false),
                    Municipal = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: false),
                    Longitude = table.Column<double>(type: "REAL", nullable: false),
                    Zone = table.Column<string>(type: "TEXT", nullable: false),
                    Exercise = table.Column<bool>(type: "INTEGER", nullable: false),
                    Public = table.Column<bool>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CallerName = table.Column<string>(type: "TEXT", nullable: false),
                    CallerPhone = table.Column<string>(type: "TEXT", nullable: false),
                    TypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    SubTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.OperationId);
                    table.ForeignKey(
                        name: "FK_Operations_OperationSubTypes_SubTypeId",
                        column: x => x.SubTypeId,
                        principalTable: "OperationSubTypes",
                        principalColumn: "OperationSubTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operations_OperationTypes_TypeId",
                        column: x => x.TypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "OperationTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserDepartmentSettings",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsVehicle = table.Column<bool>(type: "INTEGER", nullable: false),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserDepartmentSettings", x => new { x.DepartmentId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserDepartmentSettings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserDepartmentSettings_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserDepartmentSettings_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateTable(
                name: "VehicleStatuses",
                columns: table => new
                {
                    VehicleStatusId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    StatusDescription = table.Column<string>(type: "TEXT", nullable: true),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Latitude = table.Column<double>(type: "REAL", nullable: true),
                    Longitude = table.Column<double>(type: "REAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleStatuses", x => x.VehicleStatusId);
                    table.ForeignKey(
                        name: "FK_VehicleStatuses_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationTypeChecklistTasks",
                columns: table => new
                {
                    OperationTypeChecklistTaskId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IsDone = table.Column<bool>(type: "INTEGER", nullable: false),
                    DoneDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OperationTypeChecklistId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "OperationActions",
                columns: table => new
                {
                    OperationActionId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    ActionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperationId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationActions", x => x.OperationActionId);
                    table.ForeignKey(
                        name: "FK_OperationActions_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationResponses",
                columns: table => new
                {
                    OperationId = table.Column<string>(type: "TEXT", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    DispatchTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    AlertTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    AcceptedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    EnrouteTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    ArriveTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FreeTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationResponses", x => new { x.DepartmentId, x.OperationId });
                    table.ForeignKey(
                        name: "FK_OperationResponses_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationResponses_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserDepartmentSettingUserDepartmentRole",
                columns: table => new
                {
                    RolesUserDepartmentRoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersDepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserDepartmentSettingUserDepartmentRole", x => new { x.RolesUserDepartmentRoleId, x.UsersDepartmentId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserDepartmentSettingUserDepartmentRole_ApplicationUserDepartmentSettings_UsersDepartmentId_UsersUserId",
                        columns: x => new { x.UsersDepartmentId, x.UsersUserId },
                        principalTable: "ApplicationUserDepartmentSettings",
                        principalColumns: new[] { "DepartmentId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserDepartmentSettingUserDepartmentRole_UserDepartmentRoles_RolesUserDepartmentRoleId",
                        column: x => x.RolesUserDepartmentRoleId,
                        principalTable: "UserDepartmentRoles",
                        principalColumn: "UserDepartmentRoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserDepartmentSettingUserDepartmentSkill",
                columns: table => new
                {
                    SkillsUserDepartmentSkillId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersDepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    UsersUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserDepartmentSettingUserDepartmentSkill", x => new { x.SkillsUserDepartmentSkillId, x.UsersDepartmentId, x.UsersUserId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserDepartmentSettingUserDepartmentSkill_ApplicationUserDepartmentSettings_UsersDepartmentId_UsersUserId",
                        columns: x => new { x.UsersDepartmentId, x.UsersUserId },
                        principalTable: "ApplicationUserDepartmentSettings",
                        principalColumns: new[] { "DepartmentId", "UserId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserDepartmentSettingUserDepartmentSkill_UserDepartmentSkills_SkillsUserDepartmentSkillId",
                        column: x => x.SkillsUserDepartmentSkillId,
                        principalTable: "UserDepartmentSkills",
                        principalColumn: "UserDepartmentSkillId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Path = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Size = table.Column<long>(type: "INTEGER", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    OperationActionId = table.Column<int>(type: "INTEGER", nullable: true),
                    PoiId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_Files_OperationActions_OperationActionId",
                        column: x => x.OperationActionId,
                        principalTable: "OperationActions",
                        principalColumn: "OperationActionId");
                    table.ForeignKey(
                        name: "FK_Files_Pois_PoiId",
                        column: x => x.PoiId,
                        principalTable: "Pois",
                        principalColumn: "PoiId");
                });

            migrationBuilder.CreateTable(
                name: "OperationResponseVehicles",
                columns: table => new
                {
                    VehiclesVehicleId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationResponsesDepartmentId = table.Column<int>(type: "INTEGER", nullable: false),
                    OperationResponsesOperationId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationResponseVehicles", x => new { x.VehiclesVehicleId, x.OperationResponsesDepartmentId, x.OperationResponsesOperationId });
                    table.ForeignKey(
                        name: "FK_OperationResponseVehicles_OperationResponses_OperationResponsesDepartmentId_OperationResponsesOperationId",
                        columns: x => new { x.OperationResponsesDepartmentId, x.OperationResponsesOperationId },
                        principalTable: "OperationResponses",
                        principalColumns: new[] { "DepartmentId", "OperationId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationResponseVehicles_Vehicles_VehiclesVehicleId",
                        column: x => x.VehiclesVehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserOperationResponse",
                columns: table => new
                {
                    UserOperationResponseId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OperationId = table.Column<string>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    IsAccepted = table.Column<bool>(type: "INTEGER", nullable: false),
                    AcceptedTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    OperationResponseDepartmentId = table.Column<int>(type: "INTEGER", nullable: true),
                    OperationResponseOperationId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOperationResponse", x => x.UserOperationResponseId);
                    table.ForeignKey(
                        name: "FK_UserOperationResponse_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserOperationResponse_OperationResponses_OperationResponseDepartmentId_OperationResponseOperationId",
                        columns: x => new { x.OperationResponseDepartmentId, x.OperationResponseOperationId },
                        principalTable: "OperationResponses",
                        principalColumns: new[] { "DepartmentId", "OperationId" });
                    table.ForeignKey(
                        name: "FK_UserOperationResponse_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "OperationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserDepartmentSettingUserDepartmentRole_UsersDepartmentId_UsersUserId",
                table: "ApplicationUserDepartmentSettingUserDepartmentRole",
                columns: new[] { "UsersDepartmentId", "UsersUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserDepartmentSettingUserDepartmentSkill_UsersDepartmentId_UsersUserId",
                table: "ApplicationUserDepartmentSettingUserDepartmentSkill",
                columns: new[] { "UsersDepartmentId", "UsersUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserDepartmentSettings_UserId",
                table: "ApplicationUserDepartmentSettings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserDepartmentSettings_VehicleId",
                table: "ApplicationUserDepartmentSettings",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Files_OperationActionId",
                table: "Files",
                column: "OperationActionId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_PoiId",
                table: "Files",
                column: "PoiId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationActions_OperationId",
                table: "OperationActions",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationResponseVehicles_OperationResponsesDepartmentId_OperationResponsesOperationId",
                table: "OperationResponseVehicles",
                columns: new[] { "OperationResponsesDepartmentId", "OperationResponsesOperationId" });

            migrationBuilder.CreateIndex(
                name: "IX_OperationResponses_OperationId",
                table: "OperationResponses",
                column: "OperationId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Operations_SubTypeId",
                table: "Operations",
                column: "SubTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_TypeId",
                table: "Operations",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pois_DepartmentId",
                table: "Pois",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationResponse_OperationId",
                table: "UserOperationResponse",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationResponse_OperationResponseDepartmentId_OperationResponseOperationId",
                table: "UserOperationResponse",
                columns: new[] { "OperationResponseDepartmentId", "OperationResponseOperationId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationResponse_UserId",
                table: "UserOperationResponse",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleStatuses_VehicleId",
                table: "VehicleStatuses",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_DepartmentId",
                table: "Vehicles",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_WaKaWaterSources_DepartmentId",
                table: "WaKaWaterSources",
                column: "DepartmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserDepartmentSettingUserDepartmentRole");

            migrationBuilder.DropTable(
                name: "ApplicationUserDepartmentSettingUserDepartmentSkill");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "OperationResponseVehicles");

            migrationBuilder.DropTable(
                name: "OperationTypeChecklistTasks");

            migrationBuilder.DropTable(
                name: "UserOperationResponse");

            migrationBuilder.DropTable(
                name: "VehicleStatuses");

            migrationBuilder.DropTable(
                name: "WaKaWaterSources");

            migrationBuilder.DropTable(
                name: "UserDepartmentRoles");

            migrationBuilder.DropTable(
                name: "ApplicationUserDepartmentSettings");

            migrationBuilder.DropTable(
                name: "UserDepartmentSkills");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OperationActions");

            migrationBuilder.DropTable(
                name: "Pois");

            migrationBuilder.DropTable(
                name: "OperationTypeChecklists");

            migrationBuilder.DropTable(
                name: "OperationResponses");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "OperationSubTypes");

            migrationBuilder.DropTable(
                name: "OperationTypes");
        }
    }
}
