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
                    { "3bc7a629-88b1-4d36-8f2e-48a7969ad5da", "229e00e7-2a44-4f53-ba6c-544b66ad52ac", "Worker", "worker" },
                    { "9008fba6-93a0-412d-bc99-84a6cafb2be5", "b9ba2969-95bf-446b-9ebc-6a8afa2173de", "Customer", "customer" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "303adf28-a138-427d-95d1-eb2413036181", "Admin", "admin" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ee32cf6-e93c-49df-9696-97e2378d2181", 0, "aea3ddb7-e022-41f0-848c-13e326579ba3", "coby@cotton.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOgwKJwp2Eb60L+7nUYO3wlzg45+Nqt0wGkePtmYrHFSbVHcwtevALzTW7BEt3PddQ==", null, false, "5bf0f3df-b814-4788-a012-e59a8a8e078e", false, "CobyC" },
                    { "5389ca0b-0fb5-4ed0-8de5-27143f289661", 0, "66d42e7a-bbf1-4551-ba9e-e3efc52bde29", "garrett@hilbert.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEF2Dn2w/nFstupKuV8tevSepCu2HVjW4Emy7X83D054orU43mP0TlDyTaiapmdKGkg==", null, false, "8c176278-a5c6-4e38-8b34-761acd5c0676", false, "GHilbert" },
                    { "68c01fff-1c37-4fe5-be33-d2f86f716361", 0, "01f35a00-7545-4e31-a2f3-2894f702214a", "panda@monium.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGy3PkvpPxrBQJRm9yxV+enS1KTCjV12riPTeJLUpdN4NNAXXaWQUezaD5+UmlX6QQ==", null, false, "d42f507d-75b0-43ee-9200-38b3e7d675cb", false, "Panda" },
                    { "6f36bd3b-f3b7-4815-ba2a-3788a8469028", 0, "0e16334b-3d3b-474d-86da-c7fc15cb7f3f", "tyler@toney.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBppAqu6J+pxubeb0Yb//SSg8LewJ/0V+RBWZS1L3Jq0bQoRbj6a0t0LCMm5Q08edw==", null, false, "16ad3394-66d6-45ae-9b88-4bcec974678b", false, "TToney" },
                    { "89e2d93c-f59c-44ad-a2ce-890617777f07", 0, "494fcce6-703d-4367-975d-17936f887123", "cody@jones.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMREWUNWL5aSoYlvFH0iWc/YMme45YgVzot07bgtONfk+r8aWK9PzrVpuYhR2USBvQ==", null, false, "2d059a96-5cc7-4d86-9225-b51bd2359f20", false, "CJones" },
                    { "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d", 0, "022d26f4-7188-4007-b794-67c833528805", "cory@cotton.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMP8olXP+a2hzSXbwNcN7QXCdL0p6VhG5dpoOnLRZJhfBHm7HpcBmfonZoJzsbDtDQ==", null, false, "5dadfea9-f1bd-4298-bebe-bafa561a5823", false, "CoryC" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "93f08a5e-54de-4790-84b8-354b58311add", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAENTowj7dyCXKBJWKiuuS0X1UzJ0OKqIhIdfRrVg+RlpD6Q/v2fSZatUqftGGVLzEKQ==", null, false, "da95c998-0d48-4309-a11b-27bd10b86180", false, "Administrator" }
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
                    { 1, 1, null, 2 },
                    { 2, 2, null, 7 },
                    { 3, 3, null, null },
                    { 4, 4, null, null },
                    { 5, 5, null, 2 }
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
