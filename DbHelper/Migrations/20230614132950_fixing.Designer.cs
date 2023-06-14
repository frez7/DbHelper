﻿// <auto-generated />
using System;
using DbHelper.WebApi.AuthBL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DbHelper.WebApi.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230614132950_fixing")]
    partial class fixing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DbHelper.DAL.Entities.DbHelper.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CompletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExecutorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 200,
                            CustomerName = "Timely-Soft",
                            ExecutorName = "Sibers",
                            Name = "R-Keeper CRM",
                            OwnerId = 2,
                            Priority = 2,
                            StartedAt = new DateTime(2023, 6, 14, 13, 29, 50, 6, DateTimeKind.Utc).AddTicks(7946)
                        },
                        new
                        {
                            Id = 201,
                            CustomerName = "EPAM",
                            ExecutorName = "Sibers",
                            Name = "VisualTrade",
                            OwnerId = 2,
                            Priority = 1,
                            StartedAt = new DateTime(2023, 6, 14, 13, 29, 50, 6, DateTimeKind.Utc).AddTicks(7963)
                        },
                        new
                        {
                            Id = 202,
                            CustomerName = "SpaceX",
                            ExecutorName = "Sibers",
                            Name = "NASA",
                            OwnerId = 2,
                            Priority = 1,
                            StartedAt = new DateTime(2023, 6, 14, 13, 29, 50, 6, DateTimeKind.Utc).AddTicks(7973)
                        });
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.DbHelper.ProjectEmployee", b =>
                {
                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("ProjectId", "EmployeeId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("ProjectEmployees");

                    b.HasData(
                        new
                        {
                            ProjectId = 200,
                            EmployeeId = 3
                        },
                        new
                        {
                            ProjectId = 201,
                            EmployeeId = 3
                        },
                        new
                        {
                            ProjectId = 200,
                            EmployeeId = 1
                        },
                        new
                        {
                            ProjectId = 201,
                            EmployeeId = 1
                        },
                        new
                        {
                            ProjectId = 202,
                            EmployeeId = 1
                        });
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.DbHelper.ProjectTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OwnerId")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("ProjectId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 300,
                            Comment = "Надеюсь ты справишься, давай побыстрее",
                            ExecutorId = 3,
                            Name = "Разработать адронный коллайдер",
                            OwnerId = 2,
                            Priority = 1,
                            ProjectId = 202,
                            Status = 1
                        },
                        new
                        {
                            Id = 301,
                            Comment = "Надеюсь этого спринта тебе будет достаточно, удачи!",
                            ExecutorId = 1,
                            Name = "Создание машины времени",
                            OwnerId = 2,
                            Priority = 1,
                            ProjectId = 201,
                            Status = 1
                        },
                        new
                        {
                            Id = 302,
                            Comment = "Разработай бессмертие, дедлайн 3 дня",
                            ExecutorId = 1,
                            Name = "Создание панацеи",
                            OwnerId = 2,
                            Priority = 1,
                            ProjectId = 200,
                            Status = 1
                        });
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.Identity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "3b2ff15c-0e76-4585-a56a-eed70aea0a0b",
                            Email = "freezedmail@gmail.com",
                            EmailConfirmed = true,
                            FatherName = "Адылжанович",
                            FirstName = "Аширхан",
                            LastName = "Аутахунов",
                            LockoutEnabled = false,
                            NormalizedEmail = "FREEZEDMAIL@GMAIL.COM",
                            NormalizedUserName = "FREZ773",
                            PasswordHash = "AQAAAAEAACcQAAAAEFWAkFq9jvnCyv+JTvH54Lx26crtBQ8Vxb9C6eqYRc70ZmJm9lEvbHFtfhIWjhWEnw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d6c06808-968e-4e60-a37f-3b2d4bd9c266",
                            TwoFactorEnabled = false,
                            UserName = "frez773"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "4ec9a2cd-c74a-44f1-8b97-15df0016a175",
                            Email = "test1@example.com",
                            EmailConfirmed = true,
                            FatherName = "Амантурович",
                            FirstName = "Амантур",
                            LastName = "Амантуров",
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST1@EXAMPLE.COM",
                            NormalizedUserName = "TEST1",
                            PasswordHash = "AQAAAAEAACcQAAAAELyKk+YMPCQPAEL6x01Dwxft7byIVhq7WDdTNT6tFyJPZBMbaMR3NrYxBg41cj3IMQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "3eb0746a-2245-4056-bb5c-d1416caf5bdd",
                            TwoFactorEnabled = false,
                            UserName = "test1"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "aae452b1-8caa-485b-9b68-95a51cbb5493",
                            Email = "test2@example.com",
                            EmailConfirmed = true,
                            FatherName = "Атайбекович",
                            FirstName = "Атай",
                            LastName = "Атаев",
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST2@EXAMPLE.COM",
                            NormalizedUserName = "TEST2",
                            PasswordHash = "AQAAAAEAACcQAAAAENr7bLeaUfZnaqIHrYnWumn6UpuVu3Yt3lXPJQ7pHMaaUx7Iw7S2mpeccwSoTL+B9Q==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "71e77515-4e37-4f55-9c11-ca79d2cc69c5",
                            TwoFactorEnabled = false,
                            UserName = "test2"
                        });
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "57e29fd8-6654-4755-bd06-9143043e4d2e",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "0c401f9c-8ea1-49a8-8278-d94d6a18e59b",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "a7139d9d-ec7a-4dae-ad7e-49fc5524b86f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 3
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.DbHelper.Project", b =>
                {
                    b.HasOne("DbHelper.DAL.Entities.Identity.Employee", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.DbHelper.ProjectEmployee", b =>
                {
                    b.HasOne("DbHelper.DAL.Entities.Identity.Employee", "Employee")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DbHelper.DAL.Entities.DbHelper.Project", "Project")
                        .WithMany("ProjectEmployees")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.DbHelper.ProjectTask", b =>
                {
                    b.HasOne("DbHelper.DAL.Entities.Identity.Employee", "Executor")
                        .WithMany("Tasks")
                        .HasForeignKey("ExecutorId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("DbHelper.DAL.Entities.Identity.Employee", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbHelper.DAL.Entities.DbHelper.Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Executor");

                    b.Navigation("Owner");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("DbHelper.DAL.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("DbHelper.DAL.Entities.Identity.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("DbHelper.DAL.Entities.Identity.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("DbHelper.DAL.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DbHelper.DAL.Entities.Identity.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("DbHelper.DAL.Entities.Identity.Employee", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.DbHelper.Project", b =>
                {
                    b.Navigation("ProjectEmployees");

                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("DbHelper.DAL.Entities.Identity.Employee", b =>
                {
                    b.Navigation("ProjectEmployees");

                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}