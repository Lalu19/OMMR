using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class Agentmapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentName",
                table: "AgentMappings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AgentPhoneNumber",
                table: "AgentMappings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Agentrole",
                table: "AgentMappings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailId",
                table: "AgentMappings",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(4665));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(4992));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(4995));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(4997));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(4998));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(5000));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(5001));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(5004));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 622, DateTimeKind.Local).AddTicks(5008));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 618, DateTimeKind.Local).AddTicks(8100));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 619, DateTimeKind.Local).AddTicks(8116));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1083));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1402));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1405));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1407));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1409));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1411));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1412));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1414));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1415));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 623, DateTimeKind.Local).AddTicks(1416));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 621, DateTimeKind.Local).AddTicks(621));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 621, DateTimeKind.Local).AddTicks(912));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 621, DateTimeKind.Local).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 2, 7, 11, 18, 52, 621, DateTimeKind.Local).AddTicks(6870));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentName",
                table: "AgentMappings");

            migrationBuilder.DropColumn(
                name: "AgentPhoneNumber",
                table: "AgentMappings");

            migrationBuilder.DropColumn(
                name: "Agentrole",
                table: "AgentMappings");

            migrationBuilder.DropColumn(
                name: "EmailId",
                table: "AgentMappings");

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
    }
}
