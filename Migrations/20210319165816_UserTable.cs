using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class UserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(maxLength: 100, nullable: true),
                    last_name = table.Column<string>(maxLength: 100, nullable: true),
                    usernam = table.Column<string>(maxLength: 100, nullable: true),
                    password = table.Column<string>(maxLength: 100, nullable: true),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    user_picture_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
