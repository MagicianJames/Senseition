using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class UserReviewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserReview",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(nullable: false),
                    Userid = table.Column<long>(nullable: true),
                    survey_id = table.Column<long>(nullable: false),
                    Surveyid = table.Column<long>(nullable: true),
                    semeter = table.Column<string>(maxLength: 10, nullable: true),
                    course_id = table.Column<long>(nullable: false),
                    Courseid = table.Column<long>(nullable: true),
                    teacher_id = table.Column<long>(nullable: false),
                    Teacherid = table.Column<long>(nullable: true),
                    review_message = table.Column<string>(nullable: true),
                    like_no = table.Column<int>(nullable: false),
                    average_rate = table.Column<float>(nullable: false),
                    user_first_name = table.Column<string>(maxLength: 100, nullable: true),
                    user_last_name = table.Column<string>(maxLength: 100, nullable: true),
                    teacher_first_name = table.Column<string>(maxLength: 100, nullable: true),
                    teacher_last_name = table.Column<string>(maxLength: 100, nullable: true),
                    course_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReview", x => x.id);
                    table.ForeignKey(
                        name: "FK_UserReview_Course_Courseid",
                        column: x => x.Courseid,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserReview_Survey_Surveyid",
                        column: x => x.Surveyid,
                        principalTable: "Survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserReview_Teacher_Teacherid",
                        column: x => x.Teacherid,
                        principalTable: "Teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserReview_User_Userid",
                        column: x => x.Userid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_Courseid",
                table: "UserReview",
                column: "Courseid");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_Surveyid",
                table: "UserReview",
                column: "Surveyid");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_Teacherid",
                table: "UserReview",
                column: "Teacherid");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_Userid",
                table: "UserReview",
                column: "Userid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReview");
        }
    }
}
