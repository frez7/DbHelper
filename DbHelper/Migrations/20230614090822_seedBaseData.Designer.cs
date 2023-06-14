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
    [Migration("20230614090822_seedBaseData")]
    partial class seedBaseData
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
                            StartedAt = new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1461)
                        },
                        new
                        {
                            Id = 201,
                            CustomerName = "EPAM",
                            ExecutorName = "Sibers",
                            Name = "VisualTrade",
                            OwnerId = 2,
                            Priority = 1,
                            StartedAt = new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1480)
                        },
                        new
                        {
                            Id = 202,
                            CustomerName = "SpaceX",
                            ExecutorName = "Sibers",
                            Name = "NASA",
                            OwnerId = 2,
                            Priority = 1,
                            StartedAt = new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1600)
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
                            ConcurrencyStamp = "0cdf3216-49d0-4b74-9481-61937c461b5f",
                            Email = "freezedmail@gmail.com",
                            EmailConfirmed = true,
                            FatherName = "Адылжанович",
                            FirstName = "Аширхан",
                            LastName = "Аутахунов",
                            LockoutEnabled = false,
                            NormalizedEmail = "FREEZEDMAIL@GMAIL.COM",
                            NormalizedUserName = "FREZ773",
                            PasswordHash = "AQAAAAEAACcQAAAAELmbCJyHwU1DaV0SC2hNtMN8GgyU3NSIfJcVnJNrSFGKfFyJ37eWt7uDSzZKZkaYtQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ca4f93a5-1bd9-41e3-916c-ab279f9c6d5a",
                            TwoFactorEnabled = false,
                            UserName = "frez773"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "da63aa1f-3298-47d3-9445-f61e2fe9729d",
                            Email = "test1@example.com",
                            EmailConfirmed = true,
                            FatherName = "Амантурович",
                            FirstName = "Амантур",
                            LastName = "Амантуров",
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST1@EXAMPLE.COM",
                            NormalizedUserName = "TEST1",
                            PasswordHash = "AQAAAAEAACcQAAAAEP3/JIKZC1rbF4XI1G6XPY/YEHapeLsvTrnaqaijwLqnayQj/MERIHYPXPHaP8n/GA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "76b2b5bb-cdf6-477c-b667-fd89dfdcea26",
                            TwoFactorEnabled = false,
                            UserName = "test1"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "530882a4-1ac4-413f-9fcb-f56f590ba85a",
                            Email = "test2@example.com",
                            EmailConfirmed = true,
                            FatherName = "Атайбекович",
                            FirstName = "Атай",
                            LastName = "Атаев",
                            LockoutEnabled = false,
                            NormalizedEmail = "TEST2@EXAMPLE.COM",
                            NormalizedUserName = "TEST2",
                            PasswordHash = "AQAAAAEAACcQAAAAEHzlO9FS4bNsOABLInchQLIqbR8BBoB3t85yQ8lToNo10+i/ybTKKNlkeYppvaiPhA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "34b76ed0-02e8-4133-a31b-4f879433c259",
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
                            ConcurrencyStamp = "a4553290-b95d-452a-9fac-b82177ad1f63",
                            Name = "Employee",
                            NormalizedName = "EMPLOYEE"
                        },
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "32172e36-cacb-4dae-9a20-93c7ffa11d7d",
                            Name = "Manager",
                            NormalizedName = "MANAGER"
                        },
                        new
                        {
                            Id = 3,
                            ConcurrencyStamp = "066573c7-8f17-46c8-b439-40886b745e2b",
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
