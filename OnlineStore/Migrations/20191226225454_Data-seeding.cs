using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineStore.Migrations
{
    public partial class Dataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Smartphone" },
                    { 2, null, "Notebook" },
                    { 3, null, "TV" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "Path" },
                values: new object[,]
                {
                    { 1, "iphonexr.jpg" },
                    { 2, "samsung10e.jpg" },
                    { 3, "macbookpro16.jpg" },
                    { 4, "macbookpro13.jpg" },
                    { 5, "lgtv.jpg" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "Administrator" },
                    { 3, "Moderator" },
                    { 1, "SimpleUser" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "AuthValue", "CreationTime", "Email", "LastLogin", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { 2, "", null, new DateTime(2019, 12, 27, 0, 54, 53, 774, DateTimeKind.Local).AddTicks(6484), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "1[��N�W��?�}", 2, "Doe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "AuthValue", "CreationTime", "Email", "LastLogin", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { 3, "", null, new DateTime(2019, 12, 27, 0, 54, 53, 774, DateTimeKind.Local).AddTicks(7363), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ostap", "^�g�9ƏQE�/���\"	", 3, "Bondar" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Adress", "AuthValue", "CreationTime", "Email", "LastLogin", "Name", "PasswordHash", "RoleId", "Surname" },
                values: new object[] { 1, "", null, new DateTime(2019, 12, 27, 0, 54, 53, 740, DateTimeKind.Local).AddTicks(3212), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vasyl", @"%�Z҃�@
�d�mq<�", 1, "Vlasiuk" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CommentsEnabled", "CreationTime", "CreatorUserId", "Description", "ImageId", "Model", "Price", "Producer" },
                values: new object[,]
                {
                    { 1, 1, true, new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(4384), 3, "Example of description about a smartphone.", 1, "iPhone XR 64GB", 760.0m, "Apple" },
                    { 2, 1, true, new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(6097), 3, "New smartphone Samsung S10e is already in sale.", 2, "S10e SM-G970", 650.00m, "Samsung" },
                    { 3, 2, true, new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(6116), 3, "New notebook from Apple is already in our store.", 3, "Macbook Pro 16\"", 2200.00m, "Apple" },
                    { 4, 2, true, new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(6121), 3, "New notebook from Apple is already in our store.", 4, "MacBook Pro 13\" Space Gray", 1400.00m, "Apple" },
                    { 5, 3, true, new DateTime(2019, 12, 27, 0, 54, 53, 775, DateTimeKind.Local).AddTicks(6127), 3, "New TV with high resolution screen.", 5, "43UM7459", 450.00m, "LG" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
