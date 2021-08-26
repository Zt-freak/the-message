using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMessage.API.Migrations
{
    public partial class addedSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataTimeSent",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Lastname", "Name" },
                values: new object[] { 1, "john@doe.com", "Doe", "John" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Lastname", "Name" },
                values: new object[] { 2, "jane@doe.com", "Doe", "Jane" });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "Content", "SenderId", "Title" },
                values: new object[] { 1, "this is a test", 1, "Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataTimeSent",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "getdate()");
        }
    }
}
