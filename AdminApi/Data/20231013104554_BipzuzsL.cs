using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AdminApi.Data
{
    public partial class BipzuzsL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdScreen",
                columns: table => new
                {
                    AdScreenId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    TheatreName = table.Column<string>(nullable: true),
                    Screen = table.Column<string>(nullable: true),
                    AdsName = table.Column<string>(nullable: true),
                    AdsLanguage = table.Column<string>(nullable: true),
                    AdsSequence = table.Column<string>(nullable: true),
                    AdsDuration = table.Column<string>(nullable: true),
                    AdsPlaytime = table.Column<string>(nullable: true),
                    AdsYoutubeLink = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdScreen", x => x.AdScreenId);
                });

            migrationBuilder.CreateTable(
                name: "AdScreenFeedbackForm",
                columns: table => new
                {
                    AdScreenFeedbackFormId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdScreenId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    AgentId = table.Column<int>(nullable: false),
                    AdsDurationStatusOk = table.Column<int>(nullable: true),
                    AdsDurationStatusNotOk = table.Column<int>(nullable: true),
                    AdsDurationStatusRemark = table.Column<string>(nullable: true),
                    AdsPlayTimeStatusOk = table.Column<int>(nullable: true),
                    AdsPlayTimeStatusNotOk = table.Column<int>(nullable: true),
                    AdsPlayTimeStatusRemark = table.Column<string>(nullable: true),
                    AdsSequenceStatusOk = table.Column<int>(nullable: true),
                    AdsSequenceStatusNotOk = table.Column<int>(nullable: true),
                    AdsSequenceStatusRemark = table.Column<string>(nullable: true),
                    Occupancy = table.Column<string>(nullable: true),
                    LanguageStatusOk = table.Column<int>(nullable: true),
                    LanguageStatusNotOk = table.Column<int>(nullable: true),
                    LanguageStatusRemark = table.Column<string>(nullable: true),
                    TheaterInspectionStatusforMale = table.Column<int>(nullable: true),
                    TheaterInspectionStatusforFemale = table.Column<int>(nullable: true),
                    TheaterInspectionforMale = table.Column<string>(nullable: true),
                    TheaterInspectionforFemale = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdScreenFeedbackForm", x => x.AdScreenFeedbackFormId);
                });

            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(nullable: false),
                    Statename = table.Column<string>(nullable: true),
                    Cityname = table.Column<string>(nullable: true),
                    TheatreName = table.Column<string>(nullable: true),
                    AgentName = table.Column<string>(nullable: true),
                    Agentrole = table.Column<string>(nullable: true),
                    AgentPhoneNumber = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    ProfilePhoto = table.Column<string>(nullable: true),
                    AgentuserId = table.Column<string>(nullable: true),
                    PassWord = table.Column<string>(nullable: true),
                    DeleteRequested = table.Column<bool>(nullable: false),
                    AdminDeletionResponse = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentId);
                });

            migrationBuilder.CreateTable(
                name: "HallPass",
                columns: table => new
                {
                    HallPassId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(nullable: false),
                    Statename = table.Column<string>(nullable: true),
                    Cityname = table.Column<string>(nullable: true),
                    TheatreName = table.Column<string>(nullable: true),
                    HallPassImg = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HallPass", x => x.HallPassId);
                });

            migrationBuilder.CreateTable(
                name: "LogHistory",
                columns: table => new
                {
                    LogId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogCode = table.Column<string>(nullable: true),
                    LogDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    LogInTime = table.Column<DateTime>(nullable: false),
                    LogOutTime = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogHistory", x => x.LogId);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    MenuID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentID = table.Column<int>(nullable: false),
                    MenuTitle = table.Column<string>(maxLength: 100, nullable: false),
                    URL = table.Column<string>(maxLength: 500, nullable: true),
                    IsSubMenu = table.Column<int>(nullable: false),
                    SortOrder = table.Column<int>(nullable: false),
                    IconClass = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    IsMigrationData = table.Column<bool>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.MenuID);
                });

            migrationBuilder.CreateTable(
                name: "MenuGroup",
                columns: table => new
                {
                    MenuGroupID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuGroupName = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    IsMigrationData = table.Column<bool>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroup", x => x.MenuGroupID);
                });

            migrationBuilder.CreateTable(
                name: "MenuGroupWiseMenuMapping",
                columns: table => new
                {
                    MenuGroupWiseMenuMappingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuGroupId = table.Column<int>(nullable: false),
                    MenuId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IsMigrationData = table.Column<bool>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuGroupWiseMenuMapping", x => x.MenuGroupWiseMenuMappingId);
                });

            migrationBuilder.CreateTable(
                name: "ScreenList",
                columns: table => new
                {
                    ScreenListId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    District = table.Column<string>(nullable: true),
                    TheatreCode = table.Column<string>(nullable: true),
                    TheatreName = table.Column<string>(nullable: true),
                    Screen = table.Column<string>(nullable: true),
                    NoofSeats = table.Column<string>(nullable: true),
                    TheatreRating = table.Column<string>(nullable: true),
                    Rate = table.Column<string>(nullable: true),
                    Media = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScreenList", x => x.ScreenListId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateName = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "StateUser",
                columns: table => new
                {
                    StateUserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    StateId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateUser", x => x.StateUserId);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(maxLength: 100, nullable: false),
                    RoleDesc = table.Column<string>(maxLength: 500, nullable: true),
                    MenuGroupId = table.Column<int>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    IsMigrationData = table.Column<bool>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserRoleId = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 100, nullable: false),
                    Mobile = table.Column<string>(maxLength: 100, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    ImagePath = table.Column<string>(maxLength: 500, nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    AddedBy = table.Column<int>(nullable: false),
                    IsMigrationData = table.Column<bool>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    LastPasswordChangeDate = table.Column<DateTime>(nullable: true),
                    PasswordChangedBy = table.Column<int>(nullable: true),
                    IsPasswordChange = table.Column<bool>(nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(nullable: true),
                    LastUpdatedBy = table.Column<int>(nullable: true),
                    StateId = table.Column<int>(nullable: false),
                    StateName = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    AdvertiseName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Menu",
                columns: new[] { "MenuID", "AddedBy", "DateAdded", "IconClass", "IsActive", "IsMigrationData", "IsSubMenu", "LastUpdatedBy", "LastUpdatedDate", "MenuTitle", "ParentID", "SortOrder", "URL" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(498), "fas fa-home", true, true, 0, null, null, "Dashboard", 0, 1, "/DashBoard/Index" },
                    { 10, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(857), "", true, true, 0, null, null, "Change Password", 9, 0, "/User/ChangePassword" },
                    { 8, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(854), "", true, true, 0, null, null, "Profile", 5, 0, "/User/UserProfile" },
                    { 7, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(852), "", true, true, 0, null, null, "Role List", 5, 0, "/User/RoleList" },
                    { 6, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(850), "", true, true, 0, null, null, "User List", 5, 0, "/User/UserList" },
                    { 9, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(855), "fas fa-wrench", true, true, 1, null, null, "Settings", 0, 4, "" },
                    { 4, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(846), "", true, true, 0, null, null, "Menu Group List", 2, 0, "/Menu/MenuGroupList" },
                    { 3, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(844), "", true, true, 0, null, null, "Menu List", 2, 0, "/Menu/MenuList" },
                    { 2, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(841), "fas fa-ellipsis-v", true, true, 1, null, null, "Menu", 0, 2, "" },
                    { 5, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(848), "fas fa-user", true, true, 1, null, null, "User", 0, 3, "" }
                });

            migrationBuilder.InsertData(
                table: "MenuGroup",
                columns: new[] { "MenuGroupID", "AddedBy", "DateAdded", "IsActive", "IsMigrationData", "LastUpdatedBy", "LastUpdatedDate", "MenuGroupName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 13, 16, 15, 54, 297, DateTimeKind.Local).AddTicks(2713), true, true, null, null, "Super Admin Group" },
                    { 2, 1, new DateTime(2023, 10, 13, 16, 15, 54, 298, DateTimeKind.Local).AddTicks(3085), true, true, null, null, "User Group" }
                });

            migrationBuilder.InsertData(
                table: "MenuGroupWiseMenuMapping",
                columns: new[] { "MenuGroupWiseMenuMappingId", "AddedBy", "DateAdded", "IsActive", "IsMigrationData", "MenuGroupId", "MenuId" },
                values: new object[,]
                {
                    { 7, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7028), true, true, 1, 10 },
                    { 10, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7033), true, true, 2, 10 },
                    { 9, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7031), true, true, 2, 8 },
                    { 8, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7030), true, true, 2, 1 },
                    { 6, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7027), true, true, 1, 8 },
                    { 1, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(6667), true, true, 1, 1 },
                    { 4, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7024), true, true, 1, 6 },
                    { 3, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7023), true, true, 1, 4 },
                    { 2, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7020), true, true, 1, 3 },
                    { 5, 1, new DateTime(2023, 10, 13, 16, 15, 54, 301, DateTimeKind.Local).AddTicks(7025), true, true, 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "UserRoleId", "AddedBy", "DateAdded", "IsActive", "IsMigrationData", "LastUpdatedBy", "LastUpdatedDate", "MenuGroupId", "RoleDesc", "RoleName" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 10, 13, 16, 15, 54, 299, DateTimeKind.Local).AddTicks(4962), true, true, null, null, 1, null, "Admin" },
                    { 2, 1, new DateTime(2023, 10, 13, 16, 15, 54, 299, DateTimeKind.Local).AddTicks(5271), true, true, null, null, 2, null, "User" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AddedBy", "Address", "AdvertiseName", "DateAdded", "DateOfBirth", "Email", "FullName", "ImagePath", "IsActive", "IsMigrationData", "IsPasswordChange", "LastPasswordChangeDate", "LastUpdatedBy", "LastUpdatedDate", "Mobile", "Password", "PasswordChangedBy", "StateId", "StateName", "UserName", "UserRoleId" },
                values: new object[,]
                {
                    { 1, 1, null, null, new DateTime(2023, 10, 13, 16, 15, 54, 300, DateTimeKind.Local).AddTicks(2179), null, null, "Appman", null, true, true, false, null, null, null, null, "Appman@2019", null, 0, null, "developer", 1 },
                    { 2, 1, null, null, new DateTime(2023, 10, 13, 16, 15, 54, 300, DateTimeKind.Local).AddTicks(2663), null, null, "Helen Smith", null, true, true, false, null, null, null, null, "user@2020", null, 0, null, "user@2020", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdScreen");

            migrationBuilder.DropTable(
                name: "AdScreenFeedbackForm");

            migrationBuilder.DropTable(
                name: "Agents");

            migrationBuilder.DropTable(
                name: "HallPass");

            migrationBuilder.DropTable(
                name: "LogHistory");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "MenuGroup");

            migrationBuilder.DropTable(
                name: "MenuGroupWiseMenuMapping");

            migrationBuilder.DropTable(
                name: "ScreenList");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "StateUser");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
