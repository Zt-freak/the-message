using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheMessage.API.Migrations
{
    public partial class updateMessageSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataTimeSent",
                value: new DateTime(2021, 8, 26, 15, 59, 16, 85, DateTimeKind.Local).AddTicks(3826));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "Id",
                keyValue: 1,
                column: "DataTimeSent",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
