using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbHelper.WebApi.Migrations
{
    public partial class SeedNewEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "82acb065-506b-422b-bcfa-eb3e0a4815f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "cb7bf901-598e-4f58-8749-4cc0e8645f7b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "924a5b51-fd73-4db0-95af-934e88ba743a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d4a2ffeb-e35a-46db-b339-3bbb4520ab16", "AQAAAAEAACcQAAAAEJVFIFMdcl1fKnUsxbxUCxm8emW7XDUnZ/MPIVP58IQ0Md4C6ggqw7jh8C09dylIcQ==", "1915d476-167f-463f-b835-ea1af4def536" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FatherName", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RefreshToken", "RefreshTokenExpiryTime", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "c7608e11-1757-4aff-8856-c0eae86489ef", "test1@example.com", true, "Амантурович", "Амантур", "Амантуров", false, null, "TEST1@EXAMPLE.COM", "TEST1", "AQAAAAEAACcQAAAAEMs3CEOmHjt732lgWXEJU0hCLDW//8AXE/YzAVlRczb0y8okbXdqhdnmAs7pHeNCbA==", null, false, null, null, "83b04dbe-a930-40f1-a185-85a78471951c", false, "test1" },
                    { 3, 0, "47c4cfb4-c0a4-44c7-a518-3cfb1b5fc200", "test2@example.com", true, "Атайбекович", "Атай", "Атаев", false, null, "TEST2@EXAMPLE.COM", "TEST2", "AQAAAAEAACcQAAAAEJlOXXYhJuWMRkmw/P7gmefoeYWaexKfs6Bi7xsCZsP7IQo52suPVrVS9COwZDHtxA==", null, false, null, null, "4f1fac54-a1f3-4efe-b6aa-6eb702f1d340", false, "test2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0cd94ed3-8f88-4f72-87ed-f7589ce704a6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "aa6403d0-d236-4054-bd6c-a7250075f9e5");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "ea577403-1114-41a6-a2b4-25569e1e94ac");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d9fe6288-22d2-4331-806a-22cbdbcfb56e", "AQAAAAEAACcQAAAAEL00tlZ4h0s9CCdEGzFal6OxtjaBWmn8xfEzU9NR0jNgbeM+kEoAZbmokJvKIRuk1A==", "cc41352d-d163-422b-9979-7006b058d583" });
        }
    }
}
