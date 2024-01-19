using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class aowweiwx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "AnswerTable");

            migrationBuilder.AddColumn<int>(
                name: "QuestionTableId",
                table: "AnswerTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(8219));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(8998));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(9005));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(9008));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(9011));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(9015));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(9018));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(9021));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(9024));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 276, DateTimeKind.Local).AddTicks(9028));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 269, DateTimeKind.Local).AddTicks(2435));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 271, DateTimeKind.Local).AddTicks(6430));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2413));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2416));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2418));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2421));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2424));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2427));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2429));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 278, DateTimeKind.Local).AddTicks(2432));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 273, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 274, DateTimeKind.Local).AddTicks(450));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 275, DateTimeKind.Local).AddTicks(1041));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 14, 7, 19, 275, DateTimeKind.Local).AddTicks(2036));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionTableId",
                table: "AnswerTable");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "AnswerTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4062));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4595));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4600));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4610));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 555, DateTimeKind.Local).AddTicks(4613));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 549, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 551, DateTimeKind.Local).AddTicks(2964));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(4879));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5404));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5406));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5408));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5413));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5414));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 556, DateTimeKind.Local).AddTicks(5416));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 552, DateTimeKind.Local).AddTicks(9019));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 552, DateTimeKind.Local).AddTicks(9492));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 553, DateTimeKind.Local).AddTicks(7414));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 13, 57, 30, 553, DateTimeKind.Local).AddTicks(8056));
        }
    }
}
