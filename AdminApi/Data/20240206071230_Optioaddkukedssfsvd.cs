using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class Optioaddkukedssfsvd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AgentMappings",
                columns: table => new
                {
                    AgentMappingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AgentId = table.Column<int>(nullable: false),
                    TheatreName = table.Column<string>(nullable: true),
                    TaskAccepted = table.Column<bool>(nullable: false),
                    NotifiedOn = table.Column<DateTime>(nullable: true),
                    IsTimeExpired = table.Column<bool>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AgentMappings", x => x.AgentMappingId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AgentMappings");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(6672));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(6993));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(6999));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 186, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 182, DateTimeKind.Local).AddTicks(7182));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 184, DateTimeKind.Local).AddTicks(681));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(2736));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3066));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3069));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3070));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3072));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3073));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 187, DateTimeKind.Local).AddTicks(3075));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 185, DateTimeKind.Local).AddTicks(3078));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 185, DateTimeKind.Local).AddTicks(3407));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 185, DateTimeKind.Local).AddTicks(8663));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 25, 9, 34, 10, 185, DateTimeKind.Local).AddTicks(9109));
        }
    }
}
