﻿// <auto-generated />
using System;
using DudeWorkIt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Capstone_Back_End.Migrations
{
    [DbContext(typeof(DudeWorkItDbContext))]
    [Migration("20231022183309_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("DudeWorkIt.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CompletedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("DateOfProject")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int?>("ProjectTypeId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectTypeId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateOfProject = new DateTime(2023, 11, 12, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Mulch the flower beds and mow the yard",
                            ProjectTypeId = 1,
                            UserProfileId = 3
                        },
                        new
                        {
                            Id = 2,
                            DateOfProject = new DateTime(2023, 11, 12, 14, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "My garage needs to be painted. It's about 24 x 24 and I have all the paint and supplies. I can pay $15/hour.",
                            ProjectTypeId = 2,
                            UserProfileId = 4
                        },
                        new
                        {
                            Id = 3,
                            DateOfProject = new DateTime(2023, 11, 13, 9, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "I need help loading a moving truck",
                            ProjectTypeId = 3,
                            UserProfileId = 5
                        },
                        new
                        {
                            Id = 4,
                            DateOfProject = new DateTime(2023, 11, 14, 11, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Need to haul away a bunch of old furniture",
                            ProjectTypeId = 8,
                            UserProfileId = 6
                        });
                });

            modelBuilder.Entity("DudeWorkIt.Models.ProjectAssignment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ProjectId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserProfileId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserProfileId");

                    b.ToTable("ProjectAssignments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProjectId = 1,
                            UserProfileId = 2
                        },
                        new
                        {
                            Id = 2,
                            ProjectId = 2
                        },
                        new
                        {
                            Id = 3,
                            ProjectId = 3
                        },
                        new
                        {
                            Id = 4,
                            ProjectId = 4
                        });
                });

            modelBuilder.Entity("DudeWorkIt.Models.ProjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Lawn Maintenance"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Painting"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Moving"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Fencing"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Insulation"
                        },
                        new
                        {
                            Id = 6,
                            Name = "General Labor"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Gutters"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Junk Removal"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Organizing"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Volunteer"
                        });
                });

            modelBuilder.Entity("DudeWorkIt.Models.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("IdentityUserId")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("IdentityUserId");

                    b.ToTable("UserProfiles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "101 Main Street",
                            FirstName = "Admina",
                            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            LastName = "Strator"
                        },
                        new
                        {
                            Id = 2,
                            Address = "202 Broad Street",
                            FirstName = "Tyler",
                            IdentityUserId = "6f36bd3b-f3b7-4815-ba2a-3788a8469028",
                            LastName = "Toney"
                        },
                        new
                        {
                            Id = 3,
                            Address = "303 Frisco Blvd",
                            FirstName = "Garrett",
                            IdentityUserId = "5389ca0b-0fb5-4ed0-8de5-27143f289661",
                            LastName = "Hilbert"
                        },
                        new
                        {
                            Id = 4,
                            Address = "2110 Gulf ROad",
                            FirstName = "Cory",
                            IdentityUserId = "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d",
                            LastName = "Cotton"
                        },
                        new
                        {
                            Id = 5,
                            Address = "1300 Atlantic Blvd",
                            FirstName = "Coby",
                            IdentityUserId = "1ee32cf6-e93c-49df-9696-97e2378d2181",
                            LastName = "Cotton"
                        },
                        new
                        {
                            Id = 6,
                            Address = "1450 Terrace View Lane",
                            FirstName = "Cody",
                            IdentityUserId = "89e2d93c-f59c-44ad-a2ce-890617777f07",
                            LastName = "Jones"
                        },
                        new
                        {
                            Id = 7,
                            Address = "1600 Mascot Circle",
                            FirstName = "Panda",
                            IdentityUserId = "68c01fff-1c37-4fe5-be33-d2f86f716361",
                            LastName = "Monium"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                            ConcurrencyStamp = "e908b117-465e-4765-8a41-b8ed96ebcb46",
                            Name = "Admin",
                            NormalizedName = "admin"
                        },
                        new
                        {
                            Id = "3bc7a629-88b1-4d36-8f2e-48a7969ad5da",
                            ConcurrencyStamp = "efa59583-7351-4461-8fff-edde7dbeed25",
                            Name = "Worker",
                            NormalizedName = "worker"
                        },
                        new
                        {
                            Id = "9008fba6-93a0-412d-bc99-84a6cafb2be5",
                            ConcurrencyStamp = "df0dfff6-f080-4143-99b6-af639e5f4ee4",
                            Name = "Customer",
                            NormalizedName = "customer"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3940869e-e96d-4879-898b-f29468761c52",
                            Email = "admina@strator.comx",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEKHNWEbJZBE0JlE/XWuLkRDmaNfZvX+mLCA7DinzuHEkBalwTscvpozjEmStTAyATQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "2cc5f33c-1df7-44e7-bb77-0d52922ecdea",
                            TwoFactorEnabled = false,
                            UserName = "Administrator"
                        },
                        new
                        {
                            Id = "6f36bd3b-f3b7-4815-ba2a-3788a8469028",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "05e7e996-d96a-4ed8-b725-86557b2963bc",
                            Email = "tyler@toney.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEFG9gj05hPmbfR22Tai7xVn+8zCjs7FXE3PE04qfa+WT523rRGvXyPc42YsmcNFkvw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "a5a5f8bb-8bb7-4163-b132-eecb7e862c79",
                            TwoFactorEnabled = false,
                            UserName = "TToney"
                        },
                        new
                        {
                            Id = "5389ca0b-0fb5-4ed0-8de5-27143f289661",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "23c9d90f-f218-4249-8636-3fb5d3931d20",
                            Email = "garrett@hilbert.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEA08XlHj6Y0OnCfrO4iaeO5DYdgGTGuttJ64aLTwk2t2fO8HOzpkO9QmIFNVX2XhOA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "25d530dd-839a-459e-b8ea-e9e950a418f0",
                            TwoFactorEnabled = false,
                            UserName = "GHilbert"
                        },
                        new
                        {
                            Id = "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "46459e5c-1d45-45e5-97c7-b79ab6c85cfc",
                            Email = "cory@cotton.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAECiOZLCaIg1TmT2FdEatM4nyXnoEEmyFJX2W86hkSuq8Jg5TtgGgK9rtiILECer9+Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d6260698-496d-4e92-a8ac-8175d84f5f7e",
                            TwoFactorEnabled = false,
                            UserName = "CoryC"
                        },
                        new
                        {
                            Id = "1ee32cf6-e93c-49df-9696-97e2378d2181",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "b0f304d4-d27d-42c9-8200-b638680c7440",
                            Email = "coby@cotton.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEMUw7cMmFM+SvtJk+9yJiprHIRw/o6mRc/tqL5FeylsxYw42Hq4v7DhnnUkxFOd0Uw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "fdda58f1-e5ad-4ccc-b52e-3adb02d67e14",
                            TwoFactorEnabled = false,
                            UserName = "CobyC"
                        },
                        new
                        {
                            Id = "89e2d93c-f59c-44ad-a2ce-890617777f07",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "dfdeb98a-d6a0-4139-a5dc-1899aeae8f9e",
                            Email = "cody@jones.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEDmfySqvjjEiKSnlZktzUVespGks7dXiPzOHfqRbGFn5rskAROiD+POc8WkAhuvxHg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "cfa16684-2c5a-4f99-ad87-7c1f416b3037",
                            TwoFactorEnabled = false,
                            UserName = "CJones"
                        },
                        new
                        {
                            Id = "68c01fff-1c37-4fe5-be33-d2f86f716361",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "c1127d16-bd40-482e-9a21-3e2f16967f39",
                            Email = "panda@monium.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAEAACcQAAAAEE44ytpxrCUwAQXd1Y1L4bJTciz+r5VU/MVof4lvt39yzIL27RW9lKh0SSWNm1GaJg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "31bd03fe-a42a-4cc6-82f1-93cfa9fffbca",
                            TwoFactorEnabled = false,
                            UserName = "Panda"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("text");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("RoleId")
                        .HasColumnType("text");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35"
                        },
                        new
                        {
                            UserId = "6f36bd3b-f3b7-4815-ba2a-3788a8469028",
                            RoleId = "3bc7a629-88b1-4d36-8f2e-48a7969ad5da"
                        },
                        new
                        {
                            UserId = "5389ca0b-0fb5-4ed0-8de5-27143f289661",
                            RoleId = "9008fba6-93a0-412d-bc99-84a6cafb2be5"
                        },
                        new
                        {
                            UserId = "bdcf5858-0cac-42d4-8a1b-1caf0e14b92d",
                            RoleId = "9008fba6-93a0-412d-bc99-84a6cafb2be5"
                        },
                        new
                        {
                            UserId = "1ee32cf6-e93c-49df-9696-97e2378d2181",
                            RoleId = "9008fba6-93a0-412d-bc99-84a6cafb2be5"
                        },
                        new
                        {
                            UserId = "89e2d93c-f59c-44ad-a2ce-890617777f07",
                            RoleId = "9008fba6-93a0-412d-bc99-84a6cafb2be5"
                        },
                        new
                        {
                            UserId = "68c01fff-1c37-4fe5-be33-d2f86f716361",
                            RoleId = "3bc7a629-88b1-4d36-8f2e-48a7969ad5da"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Value")
                        .HasColumnType("text");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DudeWorkIt.Models.Project", b =>
                {
                    b.HasOne("DudeWorkIt.Models.ProjectType", "ProjectType")
                        .WithMany()
                        .HasForeignKey("ProjectTypeId");

                    b.HasOne("DudeWorkIt.Models.UserProfile", "UserProfile")
                        .WithMany()
                        .HasForeignKey("UserProfileId");

                    b.Navigation("ProjectType");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("DudeWorkIt.Models.ProjectAssignment", b =>
                {
                    b.HasOne("DudeWorkIt.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DudeWorkIt.Models.UserProfile", "UserProfile")
                        .WithMany("ProjectAssignments")
                        .HasForeignKey("UserProfileId");

                    b.Navigation("Project");

                    b.Navigation("UserProfile");
                });

            modelBuilder.Entity("DudeWorkIt.Models.UserProfile", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", "IdentityUser")
                        .WithMany()
                        .HasForeignKey("IdentityUserId");

                    b.Navigation("IdentityUser");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DudeWorkIt.Models.UserProfile", b =>
                {
                    b.Navigation("ProjectAssignments");
                });
#pragma warning restore 612, 618
        }
    }
}
