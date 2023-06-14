using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DbHelper.WebApi.Migrations
{
    public partial class addTasks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    OwnerId = table.Column<int>(type: "int", nullable: false),
                    ExecutorId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Enum = table.Column<int>(type: "int", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tasks_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tasks_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id");
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ExecutorId",
                table: "Tasks",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_OwnerId",
                table: "Tasks",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_ProjectId",
                table: "Tasks",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tasks");

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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c7608e11-1757-4aff-8856-c0eae86489ef", "AQAAAAEAACcQAAAAEMs3CEOmHjt732lgWXEJU0hCLDW//8AXE/YzAVlRczb0y8okbXdqhdnmAs7pHeNCbA==", "83b04dbe-a930-40f1-a185-85a78471951c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "47c4cfb4-c0a4-44c7-a518-3cfb1b5fc200", "AQAAAAEAACcQAAAAEJlOXXYhJuWMRkmw/P7gmefoeYWaexKfs6Bi7xsCZsP7IQo52suPVrVS9COwZDHtxA==", "4f1fac54-a1f3-4efe-b6aa-6eb702f1d340" });
        }
    }
}
