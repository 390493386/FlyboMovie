using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FlyboMovie.Migrations
{
    public partial class InitCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ConfirmTime = table.Column<DateTime>(nullable: true),
                    ConsumeTime = table.Column<DateTime>(nullable: true),
                    IsInactive = table.Column<bool>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    OrderNumber = table.Column<string>(maxLength: 30, nullable: false),
                    RecordCreatedTime = table.Column<DateTime>(nullable: false),
                    RecordCreatedUser = table.Column<int>(nullable: false),
                    RecordUpdatedTime = table.Column<DateTime>(nullable: true),
                    RecordUpdatedUser = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(maxLength: 50, nullable: true),
                    ValidationCode = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    CollectedCount = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 2048, nullable: true),
                    IsInactive = table.Column<bool>(nullable: false),
                    LikedCount = table.Column<int>(nullable: false),
                    MovieLink1 = table.Column<string>(maxLength: 1024, nullable: true),
                    MovieLink2 = table.Column<string>(maxLength: 1024, nullable: true),
                    MovieLink3 = table.Column<string>(maxLength: 1024, nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    PosterLink = table.Column<string>(maxLength: 1024, nullable: true),
                    Price = table.Column<int>(nullable: false),
                    RecordCreatedTime = table.Column<DateTime>(nullable: false),
                    RecordCreatedUser = table.Column<int>(nullable: false),
                    RecordUpdatedTime = table.Column<DateTime>(nullable: true),
                    RecordUpdatedUser = table.Column<int>(nullable: true),
                    TrySeconds = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderNumberSettings",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IsInactive = table.Column<bool>(nullable: false),
                    Prefix = table.Column<string>(maxLength: 10, nullable: true),
                    RecordCreatedTime = table.Column<DateTime>(nullable: false),
                    RecordCreatedUser = table.Column<int>(nullable: false),
                    RecordUpdatedTime = table.Column<DateTime>(nullable: true),
                    RecordUpdatedUser = table.Column<int>(nullable: true),
                    Seed = table.Column<int>(nullable: false),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderNumberSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IsInactive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    RecordCreatedTime = table.Column<DateTime>(nullable: false),
                    RecordCreatedUser = table.Column<int>(nullable: false),
                    RecordUpdatedTime = table.Column<DateTime>(nullable: true),
                    RecordUpdatedUser = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    IsInactive = table.Column<bool>(nullable: false),
                    RecordCreatedTime = table.Column<DateTime>(nullable: false),
                    RecordCreatedUser = table.Column<int>(nullable: false),
                    RecordUpdatedTime = table.Column<DateTime>(nullable: true),
                    RecordUpdatedUser = table.Column<int>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(maxLength: 50, nullable: false),
                    Account = table.Column<string>(maxLength: 50, nullable: false),
                    IsInactive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Points = table.Column<int>(nullable: false),
                    RecordCreatedTime = table.Column<DateTime>(nullable: false),
                    RecordCreatedUser = table.Column<int>(nullable: false),
                    RecordUpdatedTime = table.Column<DateTime>(nullable: true),
                    RecordUpdatedUser = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyOrders");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "OrderNumberSettings");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
