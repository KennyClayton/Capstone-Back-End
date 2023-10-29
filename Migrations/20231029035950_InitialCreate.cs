using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Capstone_Back_End.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    LastName = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    IdentityUserId = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "integer", nullable: false),
                    DateOfProject = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CompletedOn = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAssignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserProfileId = table.Column<int>(type: "integer", nullable: true),
                    ProjectId = table.Column<int>(type: "integer", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAssignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectAssignments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectAssignments_ProjectTypes_ProjectTypeId",
                        column: x => x.ProjectTypeId,
                        principalTable: "ProjectTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectAssignments_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3bc7a629-88b1-4d36-8f2e-48a7969ad5da", "2976f801-1587-40da-a04d-9e10ff2c2a08", "Worker", "worker" },
                    { "9008fba6-93a0-412d-bc99-84a6cafb2be5", "8491cc1e-6bfd-4f23-9534-569f92510599", "Customer", "customer" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "289ff1f8-827c-439f-8a94-86bdddc53582", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ee32cf6-e93c-49df-9696-97e2378d2181", 0, "53e4598d-55cb-47b0-9389-37aca60d0a73", "coby@cotton.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAjLiLyx2MSNJL1802H5bF+KOoe9WRkci9kh6zcDRtBtECDcBHxX6bLbstn1PbLuGg==", null, false, "692224ac-bc6c-48d5-86e5-675d9a3cd2ee", false, "CobyC" },
                    { "5389ca0b-0fb5-4ed0-8de5-27143f289661", 0, "f7efb050-52a7-4ec2-b262-a8c4da71d85f", "garrett@hilbert.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEA5U76WI43eNMBTy0eUMWBtZyk6wD9U7vxTm7vXtxIc9DkDystMN1UzBKV5E4ffufQ==", null, false, "a3f72b77-4a94-46b0-b7c7-91115ab397bf", false, "GHilbert" },
                    { "68c01fff-1c37-4fe5-be33-d2f86f716361", 0, "a180bc43-6418-4d04-9564-a6254bcf24f1", "panda@monium.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOW5u+LZydxxwWjZGYD+DFHSj0DyzDL4EHLOoe1H1DCr+jjo2zYSnheOZan3nuBalA==", null, false, "df1e2681-0d7f-435a-9073-e1fc228a6448", false, "Panda" },
                    { "6f36bd3b-f3b7-4815-ba2a-3788a8469028", 0, "57c7565e-ce71-4be5-96e6-adfa016ec23f", "tyler@toney.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENDR6ke5RRblIbV4iu2DXctan+63JMCkknWdjFq0i8xMeR905Ez/9o0nRyHFcrEd+g==", null, false, "e5c5487e-c076-413d-89cf-b379ea7ce4e7", false, "TToney" },
                    { "89e2d93c-f59c-44ad-a2ce-890617777f07", 0, "b0d2011a-670f-4fe8-8a51-aa26516d0a46", "cody@jones.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEIw9F4BT7vXyjS5MBd4xfyscFBhkx3Ql5xBzBL+IAPAZKzzQ/g+x4+7MwKwbkhpiCQ==", null, false, "3e75b35e-636e-4c22-9d20-8294ed627759", false, "CJones" },
                    { "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d", 0, "eabb85cf-62b5-4185-af31-d47b880bb82e", "cory@cotton.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENKxFVJUQ498gLiLnIg7j1WZfr5r7B9JtVMBHqrYEy3KVner78lO80PI9rnOe/azgw==", null, false, "c3ddf0e5-0b58-4570-8267-1a982b99755c", false, "CoryC" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "b7ba0b76-fb59-4d24-9cb8-ef7a50c809c1", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEKW+mEYixWw3JkOcuPiTWlhqaUAKZelcooE1PoMcFW9bDXqWEBSQ/jODyd/GnSB/4A==", null, false, "2cc9cdb1-1643-4cb0-bd6f-d882a99a1820", false, "Administrator" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Lawn Maintenance" },
                    { 2, "Painting" },
                    { 3, "Moving" },
                    { 4, "Fencing" },
                    { 5, "Insulation" },
                    { 6, "General Labor" },
                    { 7, "Gutters" },
                    { 8, "Junk Removal" },
                    { 9, "Organizing" },
                    { 10, "Volunteer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "9008fba6-93a0-412d-bc99-84a6cafb2be5", "1ee32cf6-e93c-49df-9696-97e2378d2181" },
                    { "9008fba6-93a0-412d-bc99-84a6cafb2be5", "5389ca0b-0fb5-4ed0-8de5-27143f289661" },
                    { "3bc7a629-88b1-4d36-8f2e-48a7969ad5da", "68c01fff-1c37-4fe5-be33-d2f86f716361" },
                    { "3bc7a629-88b1-4d36-8f2e-48a7969ad5da", "6f36bd3b-f3b7-4815-ba2a-3788a8469028" },
                    { "9008fba6-93a0-412d-bc99-84a6cafb2be5", "89e2d93c-f59c-44ad-a2ce-890617777f07" },
                    { "9008fba6-93a0-412d-bc99-84a6cafb2be5", "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "FirstName", "IdentityUserId", "LastName" },
                values: new object[,]
                {
                    { 1, "101 Main Street", "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator" },
                    { 2, "202 Broad Street", "Tyler", "6f36bd3b-f3b7-4815-ba2a-3788a8469028", "Toney" },
                    { 3, "303 Frisco Blvd", "Garrett", "5389ca0b-0fb5-4ed0-8de5-27143f289661", "Hilbert" },
                    { 4, "2110 Gulf ROad", "Cory", "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d", "Cotton" },
                    { 5, "1300 Atlantic Blvd", "Coby", "1ee32cf6-e93c-49df-9696-97e2378d2181", "Cotton" },
                    { 6, "1450 Terrace View Lane", "Cody", "89e2d93c-f59c-44ad-a2ce-890617777f07", "Jones" },
                    { 7, "1600 Mascot Circle", "Panda", "68c01fff-1c37-4fe5-be33-d2f86f716361", "Monium" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompletedOn", "DateOfProject", "Description", "ProjectTypeId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 11, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), "Mulch the flower beds and mow the yard", 1, 3 },
                    { 2, new DateTime(2023, 11, 12, 16, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 11, 12, 8, 0, 0, 0, DateTimeKind.Unspecified), "My garage needs to be painted. It's about 24 x 24 and I have all the paint and supplies. I can pay $15/hour.", 2, 4 },
                    { 3, null, new DateTime(2023, 11, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), "I need help loading a moving truck", 3, 5 },
                    { 4, null, new DateTime(2023, 11, 14, 11, 30, 0, 0, DateTimeKind.Unspecified), "Need to haul away a bunch of old furniture", 8, 6 },
                    { 5, null, new DateTime(2023, 11, 14, 11, 30, 0, 0, DateTimeKind.Unspecified), "I think my gutters are clogged, and they ain't gonna clean themselves. Hurry up.", 7, 6 }
                });

            migrationBuilder.InsertData(
                table: "ProjectAssignments",
                columns: new[] { "Id", "ProjectId", "ProjectTypeId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 1, 1, 2 },
                    { 2, 2, 2, 7 },
                    { 3, 3, 3, null },
                    { 4, 4, 8, null },
                    { 5, 5, 7, 2 }
                });

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
                name: "IX_ProjectAssignments_ProjectId",
                table: "ProjectAssignments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignments_ProjectTypeId",
                table: "ProjectAssignments",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignments_UserProfileId",
                table: "ProjectAssignments",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserProfileId",
                table: "Projects",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "ProjectAssignments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
