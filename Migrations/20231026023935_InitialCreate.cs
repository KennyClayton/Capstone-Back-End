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
                    ProjectTypeId = table.Column<int>(type: "integer", nullable: true)
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
                        principalColumn: "Id");
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
                    { "3bc7a629-88b1-4d36-8f2e-48a7969ad5da", "6b3821b6-e9b8-49cd-85b2-58ff7c7bb6b6", "Worker", "worker" },
                    { "9008fba6-93a0-412d-bc99-84a6cafb2be5", "605e00e6-c3f3-462b-a6a5-2a2994d9e28c", "Customer", "customer" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "8723815f-6c39-4db8-a3f5-f63ac1a3eaaa", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ee32cf6-e93c-49df-9696-97e2378d2181", 0, "e66238c7-cf5a-4b99-8e2b-20134d8f0cda", "coby@cotton.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEFGdRlCrbgO+2xxQG3bQ2gPaLN9ZQMCkZaL5mkI8ualCP/QGIIJRFul5bzBj21JfBw==", null, false, "b82b7e92-35a8-4513-8cd0-4b5fc76c8d4c", false, "CobyC" },
                    { "5389ca0b-0fb5-4ed0-8de5-27143f289661", 0, "2849d5fa-113e-417b-b2a1-d8c23946ba02", "garrett@hilbert.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGqdpm+Pu/lQ/e4iE1xPjGU/8CyzLII+HXcCoR2dz2O6amFXlBs5KDZw1ULutHuF2A==", null, false, "6baae1cc-c440-4b22-8a87-d874ff618a0b", false, "GHilbert" },
                    { "68c01fff-1c37-4fe5-be33-d2f86f716361", 0, "4b1164c3-67d9-4290-ab9f-224a5dd0d6d2", "panda@monium.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEILVKQZNKkqp7ANf8g4pCqcfO2eusJeGcRaV8ZNFmniCKA6ehVR1cPzw1V1W1YluMQ==", null, false, "50f5a956-d2ef-49a5-8d32-f77194507b7c", false, "Panda" },
                    { "6f36bd3b-f3b7-4815-ba2a-3788a8469028", 0, "b185931b-05fc-4ffb-9ef8-0dd2d71a9188", "tyler@toney.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBM3ZRnjJKITnf4BzxJ7dFPysFOs13L6WqVPb3LrTR/ZzKZn10J0qWA8hKpe8/x2CA==", null, false, "212f8098-9409-464d-bcaa-fa2454729171", false, "TToney" },
                    { "89e2d93c-f59c-44ad-a2ce-890617777f07", 0, "0b8a35d0-5ed8-4618-a92d-6d982d7ccebc", "cody@jones.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEORgJ2UwxWeTkKHw5TX0OzhF86zm2znwGkt5RZsn30XpSTayibWOBL//ptwFbEiGgA==", null, false, "2a7bd7e4-4f2a-4d9d-ab6d-0f210b5248d3", false, "CJones" },
                    { "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d", 0, "3c204d14-d1ed-4853-ad32-7eebf80aca4b", "cory@cotton.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEH0zs2j+2aXtv7pyuEzykDXy8IkhiyDJZiTP2/5M7Iz+wfbAwXPvgFdHZ1vNfNj0wg==", null, false, "4f0145ba-84b0-4be3-94be-229a33e58b92", false, "CoryC" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "45e1dfba-6240-4bc0-84f5-8b934d1a4e1a", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAECePZ4mfb0iWRq7+9GTQpwcUT0FBfeMXvB9LTZuvkrCIUYYhvNxuf1qIlIMa5JQ63A==", null, false, "5497efb2-d68f-4409-9377-5631272d78bc", false, "Administrator" }
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
                    { 1, null, new DateTime(2023, 11, 12, 11, 0, 0, 0, DateTimeKind.Unspecified), "Mulch the flower beds and mow the yard", 1, 3 },
                    { 2, null, new DateTime(2023, 11, 12, 14, 0, 0, 0, DateTimeKind.Unspecified), "My garage needs to be painted. It's about 24 x 24 and I have all the paint and supplies. I can pay $15/hour.", 2, 4 },
                    { 3, null, new DateTime(2023, 11, 13, 9, 0, 0, 0, DateTimeKind.Unspecified), "I need help loading a moving truck", 3, 5 },
                    { 4, null, new DateTime(2023, 11, 14, 11, 30, 0, 0, DateTimeKind.Unspecified), "Need to haul away a bunch of old furniture", 8, 6 }
                });

            migrationBuilder.InsertData(
                table: "ProjectAssignments",
                columns: new[] { "Id", "ProjectId", "ProjectTypeId", "UserProfileId" },
                values: new object[,]
                {
                    { 1, 1, null, 2 },
                    { 2, 2, null, null },
                    { 3, 3, null, null },
                    { 4, 4, null, null }
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
