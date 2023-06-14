using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbHelper.WebApi.Migrations
{
    public partial class seedBaseData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "CompletedAt", "CustomerName", "ExecutorName", "Name", "OwnerId", "Priority", "StartedAt" },
                values: new object[,]
                {
                    { 200, null, "Timely-Soft", "Sibers", "R-Keeper CRM", 2, 2, new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1461) },
                    { 201, null, "EPAM", "Sibers", "VisualTrade", 2, 1, new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1480) },
                    { 202, null, "SpaceX", "Sibers", "NASA", 2, 1, new DateTime(2023, 6, 14, 9, 8, 22, 259, DateTimeKind.Utc).AddTicks(1600) }
                });

            migrationBuilder.InsertData(
                table: "ProjectEmployees",
                columns: new[] { "EmployeeId", "ProjectId" },
                values: new object[,]
                {
                    { 1, 200 },
                    { 3, 200 },
                    { 1, 201 },
                    { 3, 201 },
                    { 1, 202 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Comment", "ExecutorId", "Name", "OwnerId", "Priority", "ProjectId", "Status" },
                values: new object[,]
                {
                    { 300, "Надеюсь ты справишься, давай побыстрее", 3, "Разработать адронный коллайдер", 2, 1, 202, 1 },
                    { 301, "Надеюсь этого спринта тебе будет достаточно, удачи!", 1, "Создание машины времени", 2, 1, 201, 1 },
                    { 302, "Разработай бессмертие, дедлайн 3 дня", 1, "Создание панацеи", 2, 1, 200, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1, 200 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 3, 200 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1, 201 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 3, 201 });

            migrationBuilder.DeleteData(
                table: "ProjectEmployees",
                keyColumns: new[] { "EmployeeId", "ProjectId" },
                keyValues: new object[] { 1, 202 });

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "4633d52f-4d3c-4ec0-94c7-64902042975f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "8819c228-2cd9-43d2-8f93-8258936d2dfe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "13e8c5b5-1d6a-4762-b71d-790bb5f6e565");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7f586a86-3aaa-45ca-82d7-5455f60b612d", "AQAAAAEAACcQAAAAEHYMnvg9Z2L8KbUKcmg2OniBSHfzuMtk9fioYy/6r36Ubp3Jl91cAG4m4hV8h/9i8A==", "7bdced43-a57d-4391-a7a8-0d89dd6fe03b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27416ef4-404f-4c9e-ba8c-b6471b0b8455", "AQAAAAEAACcQAAAAEHX2WlxryK4VQt8GdttMjezrpmDMGcWv8ylAKD+mLqXHr2QAFvh1eJFmebd2P5P57g==", "64c5e4f5-f757-44e9-98b1-f7ae2dba39fe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3be55e55-de63-4fc7-97e5-f79a683e51ca", "AQAAAAEAACcQAAAAEIRtt1P/mmgbFpn5pa1P4BU7CQkQKvj0LorOqRJq/wRLzv0BGvDngPC4Go71x+o5Ag==", "680147ef-fe1d-47e4-861e-0644fb83eadd" });
        }
    }
}
