using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbHelper.WebApi.Migrations
{
    public partial class fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "57e29fd8-6654-4755-bd06-9143043e4d2e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0c401f9c-8ea1-49a8-8278-d94d6a18e59b");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "a7139d9d-ec7a-4dae-ad7e-49fc5524b86f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3b2ff15c-0e76-4585-a56a-eed70aea0a0b", "AQAAAAEAACcQAAAAEFWAkFq9jvnCyv+JTvH54Lx26crtBQ8Vxb9C6eqYRc70ZmJm9lEvbHFtfhIWjhWEnw==", "d6c06808-968e-4e60-a37f-3b2d4bd9c266" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4ec9a2cd-c74a-44f1-8b97-15df0016a175", "AQAAAAEAACcQAAAAELyKk+YMPCQPAEL6x01Dwxft7byIVhq7WDdTNT6tFyJPZBMbaMR3NrYxBg41cj3IMQ==", "3eb0746a-2245-4056-bb5c-d1416caf5bdd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aae452b1-8caa-485b-9b68-95a51cbb5493", "AQAAAAEAACcQAAAAENr7bLeaUfZnaqIHrYnWumn6UpuVu3Yt3lXPJQ7pHMaaUx7Iw7S2mpeccwSoTL+B9Q==", "71e77515-4e37-4f55-9c11-ca79d2cc69c5" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 200,
                column: "StartedAt",
                value: new DateTime(2023, 6, 14, 13, 29, 50, 6, DateTimeKind.Utc).AddTicks(7946));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 201,
                column: "StartedAt",
                value: new DateTime(2023, 6, 14, 13, 29, 50, 6, DateTimeKind.Utc).AddTicks(7963));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 202,
                column: "StartedAt",
                value: new DateTime(2023, 6, 14, 13, 29, 50, 6, DateTimeKind.Utc).AddTicks(7973));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "a4553290-b95d-452a-9fac-b82177ad1f63");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "32172e36-cacb-4dae-9a20-93c7ffa11d7d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "066573c7-8f17-46c8-b439-40886b745e2b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0cdf3216-49d0-4b74-9481-61937c461b5f", "AQAAAAEAACcQAAAAELmbCJyHwU1DaV0SC2hNtMN8GgyU3NSIfJcVnJNrSFGKfFyJ37eWt7uDSzZKZkaYtQ==", "ca4f93a5-1bd9-41e3-916c-ab279f9c6d5a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "da63aa1f-3298-47d3-9445-f61e2fe9729d", "AQAAAAEAACcQAAAAEP3/JIKZC1rbF4XI1G6XPY/YEHapeLsvTrnaqaijwLqnayQj/MERIHYPXPHaP8n/GA==", "76b2b5bb-cdf6-477c-b667-fd89dfdcea26" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "530882a4-1ac4-413f-9fcb-f56f590ba85a", "AQAAAAEAACcQAAAAEHzlO9FS4bNsOABLInchQLIqbR8BBoB3t85yQ8lToNo10+i/ybTKKNlkeYppvaiPhA==", "34b76ed0-02e8-4133-a31b-4f879433c259" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 200,
                column: "StartedAt",
                value: new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1461));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 201,
                column: "StartedAt",
                value: new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 202,
                column: "StartedAt",
                value: new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1600));
        }
    }
}
