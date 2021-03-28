using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class TeacherTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Teacher",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(maxLength: 100, nullable: true),
                    last_name = table.Column<string>(maxLength: 100, nullable: true),
                    position = table.Column<string>(maxLength: 100, nullable: true),
                    biography = table.Column<string>(nullable: true),
                    birthdate = table.Column<DateTime>(nullable: false),
                    age = table.Column<byte>(nullable: false),
                    rate = table.Column<byte>(nullable: false),
                    picture_url = table.Column<string>(nullable: true),
                    major_id = table.Column<long>(nullable: false),
                    Majorid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teacher_Major_Majorid",
                        column: x => x.Majorid,
                        principalTable: "Major",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Majorid",
                table: "Teacher",
                column: "Majorid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Teacher");
        }
    }
}
