using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class ServeyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Survey",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    answer_question1 = table.Column<byte>(nullable: false),
                    answer_question2 = table.Column<byte>(nullable: false),
                    answer_question3 = table.Column<byte>(nullable: false),
                    answer_question4 = table.Column<byte>(nullable: false),
                    answer_question5 = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Survey", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Survey");
        }
    }
}
