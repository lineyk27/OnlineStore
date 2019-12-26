using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class Dataseedingbugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 58, 6, 795, DateTimeKind.Local).AddTicks(6364));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 58, 6, 795, DateTimeKind.Local).AddTicks(8252));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 58, 6, 795, DateTimeKind.Local).AddTicks(8284));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 58, 6, 795, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 58, 6, 795, DateTimeKind.Local).AddTicks(8303));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "Email" },
                values: new object[] { new DateTime(2019, 12, 27, 0, 58, 6, 781, DateTimeKind.Local).AddTicks(3864), "vasylvlasiuk@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationTime", "Email" },
                values: new object[] { new DateTime(2019, 12, 27, 0, 58, 6, 794, DateTimeKind.Local).AddTicks(7558), "johndoe@gmail.com" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationTime", "Email" },
                values: new object[] { new DateTime(2019, 12, 27, 0, 58, 6, 794, DateTimeKind.Local).AddTicks(8244), "ostepbondar@gmail.com" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(6097));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(6116));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(6121));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(6127));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreationTime", "Email" },
                values: new object[] { new DateTime(2019, 12, 27, 0, 54, 53, 740, DateTimeKind.Local).AddTicks(3212), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreationTime", "Email" },
                values: new object[] { new DateTime(2019, 12, 27, 0, 54, 53, 774, DateTimeKind.Local).AddTicks(6484), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreationTime", "Email" },
                values: new object[] { new DateTime(2019, 12, 27, 0, 54, 53, 774, DateTimeKind.Local).AddTicks(7363), null });
        }
    }
}
