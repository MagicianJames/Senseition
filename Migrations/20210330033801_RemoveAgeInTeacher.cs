using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class RemoveAgeInTeacher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "age",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "birthdate",
                table: "Teacher");

            migrationBuilder.AlterColumn<float>(
                name: "rate",
                table: "Teacher",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte>(
                name: "rate",
                table: "Teacher",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(float));

            migrationBuilder.AddColumn<byte>(
                name: "age",
                table: "Teacher",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "birthdate",
                table: "Teacher",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
