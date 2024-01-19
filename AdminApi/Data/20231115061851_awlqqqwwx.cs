using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class awlqqqwwx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionTableId",
                table: "AnswerTable");

            migrationBuilder.AddColumn<int>(
                name: "QuestionId",
                table: "AnswerTable",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Options",
                columns: table => new
                {
                    OptionsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(nullable: false),
                    Option = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Options", x => x.OptionsId);
                });

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 644, DateTimeKind.Local).AddTicks(9985));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1302));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1312));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1316));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1325));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1329));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1333));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1337));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 645, DateTimeKind.Local).AddTicks(1341));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 634, DateTimeKind.Local).AddTicks(2101));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 637, DateTimeKind.Local).AddTicks(392));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(1113));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2892));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2904));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2908));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2911));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2915));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2918));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2921));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2925));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 647, DateTimeKind.Local).AddTicks(2928));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 640, DateTimeKind.Local).AddTicks(3015));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 640, DateTimeKind.Local).AddTicks(4413));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 642, DateTimeKind.Local).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 15, 11, 48, 50, 642, DateTimeKind.Local).AddTicks(3718));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Options");

            migrationBuilder.DropColumn(
                name: "QuestionId",
                table: "AnswerTable");

            migrationBuilder.AddColumn<int>(
                name: "QuestionTableId",
                table: "AnswerTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2009));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2013));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2017));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2019));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2021));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2023));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2025));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 136, DateTimeKind.Local).AddTicks(2027));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 130, DateTimeKind.Local).AddTicks(2761));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 132, DateTimeKind.Local).AddTicks(198));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3304));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3832));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3836));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3838));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3840));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3842));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3845));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 137, DateTimeKind.Local).AddTicks(3848));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 133, DateTimeKind.Local).AddTicks(8396));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 133, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 134, DateTimeKind.Local).AddTicks(7941));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 11, 13, 11, 55, 54, 134, DateTimeKind.Local).AddTicks(8572));
        }
    }
}
