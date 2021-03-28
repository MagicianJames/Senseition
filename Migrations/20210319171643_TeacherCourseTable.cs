using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class TeacherCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherCourse",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_id = table.Column<long>(nullable: false),
                    Teacherid = table.Column<long>(nullable: true),
                    course_id = table.Column<long>(nullable: false),
                    Courseid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourse", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Course_Courseid",
                        column: x => x.Courseid,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Teacher_Teacherid",
                        column: x => x.Teacherid,
                        principalTable: "Teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourse_Courseid",
                table: "TeacherCourse",
                column: "Courseid");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourse_Teacherid",
                table: "TeacherCourse",
                column: "Teacherid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCourse");
        }
    }
}
