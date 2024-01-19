using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class BiopusxszzzzssL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "AdScreenFeedbackForm",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3463));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3784));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3789));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3793));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3794));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3796));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3798));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3800));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(3802));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 462, DateTimeKind.Local).AddTicks(7866));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 463, DateTimeKind.Local).AddTicks(7472));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 466, DateTimeKind.Local).AddTicks(9716));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(42));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(45));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(46));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(47));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(49));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(98));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(100));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(101));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 467, DateTimeKind.Local).AddTicks(102));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 464, DateTimeKind.Local).AddTicks(9667));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 464, DateTimeKind.Local).AddTicks(9964));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 465, DateTimeKind.Local).AddTicks(5251));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 49, 23, 465, DateTimeKind.Local).AddTicks(5688));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "AdScreenFeedbackForm",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9102));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9495));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9497));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9499));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9501));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9503));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9505));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9507));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 682, DateTimeKind.Local).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 678, DateTimeKind.Local).AddTicks(933));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 679, DateTimeKind.Local).AddTicks(5448));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7436));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7887));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7890));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7891));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7892));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7894));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7895));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7897));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7898));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 683, DateTimeKind.Local).AddTicks(7900));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 681, DateTimeKind.Local).AddTicks(976));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 681, DateTimeKind.Local).AddTicks(1307));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 681, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 16, 18, 46, 16, 681, DateTimeKind.Local).AddTicks(8757));
        }
    }
}
