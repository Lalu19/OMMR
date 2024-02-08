using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class Opagentytd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "AgentMappings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7298));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7642));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7647));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7649));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7650));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7654));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7656));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7658));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 813, DateTimeKind.Local).AddTicks(7659));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 808, DateTimeKind.Local).AddTicks(9375));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 809, DateTimeKind.Local).AddTicks(9851));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(3881));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4274));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4276));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4278));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4280));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4282));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4285));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4286));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 814, DateTimeKind.Local).AddTicks(4288));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 811, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 811, DateTimeKind.Local).AddTicks(7571));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 812, DateTimeKind.Local).AddTicks(5738));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 14, 45, 18, 812, DateTimeKind.Local).AddTicks(6355));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StateId",
                table: "AgentMappings");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 138, DateTimeKind.Local).AddTicks(9974));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(304));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(306));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(308));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(310));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(312));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(313));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(315));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(317));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(318));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 135, DateTimeKind.Local).AddTicks(2763));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 136, DateTimeKind.Local).AddTicks(924));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7309));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7683));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7686));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7688));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7689));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7691));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7692));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7694));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7696));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 139, DateTimeKind.Local).AddTicks(7697));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 137, DateTimeKind.Local).AddTicks(4542));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 137, DateTimeKind.Local).AddTicks(4867));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 138, DateTimeKind.Local).AddTicks(871));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 6, 12, 42, 30, 138, DateTimeKind.Local).AddTicks(1379));
        }
    }
}
