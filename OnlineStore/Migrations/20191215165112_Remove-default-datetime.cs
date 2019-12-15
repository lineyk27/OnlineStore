using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class Removedefaultdatetime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Users",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 15, 18, 49, 32, 269, DateTimeKind.Local).AddTicks(4152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Products",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2019, 12, 15, 18, 49, 32, 300, DateTimeKind.Local).AddTicks(5745));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 15, 18, 49, 32, 269, DateTimeKind.Local).AddTicks(4152),
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationTime",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2019, 12, 15, 18, 49, 32, 300, DateTimeKind.Local).AddTicks(5745),
                oldClrType: typeof(DateTime));
        }
    }
}
