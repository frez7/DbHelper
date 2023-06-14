using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbHelper.WebApi.Migrations
{
    public partial class fixTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Enum",
                table: "Tasks",
                newName: "Status");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Tasks",
                newName: "Enum");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "67914feb-ba3c-4da9-a47e-2b01407bddae");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "0fd0d682-f690-4699-bf16-fe22fda82063");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "03732727-1a2f-4ee9-ae5f-670e2d0b91a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "43de6af9-d6f4-402e-b902-c8e6a1b6a061", "AQAAAAEAACcQAAAAELivbQ4WmmCq/zuDUT6RWBC1vusRXli1ReIbbvq+eDAWakPSf/JeFkzt10tz/1a/7A==", "eea9ae73-6ea8-4fb3-b320-641999800628" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "22b9aa35-665f-4764-850b-d43744d3153f", "AQAAAAEAACcQAAAAEGa8GbViWBre2tNSJyoWU1f1svePdXYXQ5TtNOVXDdSzY6a9cNoO3EzrKluGypfojg==", "0f82467c-3d33-4213-83f1-b01668f4b854" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3a3d9e7-bc84-43d4-84f8-f55dc814c5fc", "AQAAAAEAACcQAAAAECAaLYDACzx+AKPFSC8UDMCrekyCSbhe+XswaW2255onyTBVs7iKgInbKPtRLX5vhA==", "07aa831e-bbad-4ec2-ae6f-3310b60f1451" });
        }
    }
}
