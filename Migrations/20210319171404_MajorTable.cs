using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class MajorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major_name = table.Column<string>(maxLength: 100, nullable: true),
                    facult_id = table.Column<long>(nullable: false),
                    Facultyid = table.Column<long>(nullable: true),
                    major_logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.id);
                    table.ForeignKey(
                        name: "FK_Major_Faculty_Facultyid",
                        column: x => x.Facultyid,
                        principalTable: "Faculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Major_Facultyid",
                table: "Major",
                column: "Facultyid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Major");
        }
    }
}
