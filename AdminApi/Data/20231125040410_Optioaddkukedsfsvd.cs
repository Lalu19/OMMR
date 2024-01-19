using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class Optioaddkukedsfsvd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OptionId",
                table: "AnswerTable",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "OptionId",
                table: "AnswerTable",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(5603));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(5988));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(5992));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(5994));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(5995));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(5997));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(6030));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(6032));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(6034));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 752, DateTimeKind.Local).AddTicks(6035));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 748, DateTimeKind.Local).AddTicks(1202));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 749, DateTimeKind.Local).AddTicks(8356));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2243));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2246));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2248));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2249));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2250));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2252));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2254));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2255));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 753, DateTimeKind.Local).AddTicks(2256));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 751, DateTimeKind.Local).AddTicks(1958));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 751, DateTimeKind.Local).AddTicks(2271));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 751, DateTimeKind.Local).AddTicks(7631));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 24, 15, 40, 8, 751, DateTimeKind.Local).AddTicks(8066));
        }
    }
}
