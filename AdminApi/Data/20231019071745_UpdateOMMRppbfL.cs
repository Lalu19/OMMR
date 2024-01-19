using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class UpdateOMMRppbfL : Migration
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

            migrationBuilder.AddColumn<bool>(
                name: "DeleteRequested",
                table: "StateUser",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "AdsVariantStatusNotOk",
                table: "AdScreenFeedbackForm",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdsVariantStatusOk",
                table: "AdScreenFeedbackForm",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AdsVariantStatusRemark",
                table: "AdScreenFeedbackForm",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1089));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1093));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1095));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1096));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1098));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1099));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1100));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1104));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(1106));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 786, DateTimeKind.Local).AddTicks(8416));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 788, DateTimeKind.Local).AddTicks(2343));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7474));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7833));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7835));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7837));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7838));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7840));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7841));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7843));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7844));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 791, DateTimeKind.Local).AddTicks(7845));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 789, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 789, DateTimeKind.Local).AddTicks(5446));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 790, DateTimeKind.Local).AddTicks(982));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 19, 12, 47, 44, 790, DateTimeKind.Local).AddTicks(1458));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeleteRequested",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SuperAdminDeletionResponse",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "DeleteRequested",
                table: "StateUser");

            migrationBuilder.DropColumn(
                name: "AdsVariantStatusNotOk",
                table: "AdScreenFeedbackForm");

            migrationBuilder.DropColumn(
                name: "AdsVariantStatusOk",
                table: "AdScreenFeedbackForm");

            migrationBuilder.DropColumn(
                name: "AdsVariantStatusRemark",
                table: "AdScreenFeedbackForm");

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8181));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8508));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8511));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8513));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8516));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8518));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8519));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8520));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8522));

            migrationBuilder.UpdateData(
                table: "Menu",
                keyColumn: "MenuID",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 343, DateTimeKind.Local).AddTicks(8523));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 338, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "MenuGroup",
                keyColumn: "MenuGroupID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 340, DateTimeKind.Local).AddTicks(9163));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6214));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6652));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6655));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6656));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6658));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6660));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 7,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6661));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 8,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6663));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 9,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6665));

            migrationBuilder.UpdateData(
                table: "MenuGroupWiseMenuMapping",
                keyColumn: "MenuGroupWiseMenuMappingId",
                keyValue: 10,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 344, DateTimeKind.Local).AddTicks(6667));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 342, DateTimeKind.Local).AddTicks(3111));

            migrationBuilder.UpdateData(
                table: "UserRole",
                keyColumn: "UserRoleId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 342, DateTimeKind.Local).AddTicks(3420));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 342, DateTimeKind.Local).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 10, 17, 19, 13, 57, 342, DateTimeKind.Local).AddTicks(9662));
        }
    }
}
