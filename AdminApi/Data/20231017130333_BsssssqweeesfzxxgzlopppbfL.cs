using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class BsssssqweeesfzxxgzlopppbfL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DeleteRequested",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SuperAdminDeletionResponse",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4910));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4912));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 842, DateTimeKind.Local).AddTicks(4914));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 836, DateTimeKind.Local).AddTicks(9251));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 838, DateTimeKind.Local).AddTicks(3397));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5047));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5050));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5052));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5054));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5055));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5057));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5059));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5060));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 843, DateTimeKind.Local).AddTicks(5061));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 840, DateTimeKind.Local).AddTicks(2593));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 840, DateTimeKind.Local).AddTicks(3036));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 841, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 18, 33, 32, 841, DateTimeKind.Local).AddTicks(2383));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteRequested",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SuperAdminDeletionResponse",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5747));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5750));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5752));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5754));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5756));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5758));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5759));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5761));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 140, DateTimeKind.Local).AddTicks(5763));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 136, DateTimeKind.Local).AddTicks(7447));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 137, DateTimeKind.Local).AddTicks(7090));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(1945));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2294));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2297));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2299));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2300));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2303));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2305));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2306));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 141, DateTimeKind.Local).AddTicks(2308));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 139, DateTimeKind.Local).AddTicks(1182));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 139, DateTimeKind.Local).AddTicks(1505));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 139, DateTimeKind.Local).AddTicks(7184));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 17, 43, 49, 139, DateTimeKind.Local).AddTicks(7652));
        }
    }
}
