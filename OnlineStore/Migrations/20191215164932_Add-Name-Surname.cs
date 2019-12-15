using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class AddNameSurname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 15, 18, 49, 32, 269, DateTimeKind.Local).AddTicks(4152),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 15, 17, 33, 15, 686, DateTimeKind.Local).AddTicks(717));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Users",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Users",
                maxLength: 32,
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 15, 18, 49, 32, 300, DateTimeKind.Local).AddTicks(5745),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 15, 17, 33, 15, 716, DateTimeKind.Local).AddTicks(7479));

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Administrator" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "SimpleUser" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Users");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 15, 17, 33, 15, 686, DateTimeKind.Local).AddTicks(717),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 15, 18, 49, 32, 269, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 15, 17, 33, 15, 716, DateTimeKind.Local).AddTicks(7479),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 12, 15, 18, 49, 32, 300, DateTimeKind.Local).AddTicks(5745));
        }
    }
}
