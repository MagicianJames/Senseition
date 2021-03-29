using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class ReCreateForeignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Faculty",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    faculty_name = table.Column<string>(maxLength: 100, nullable: true),
                    logo_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faculty", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(maxLength: 100, nullable: true),
                    last_name = table.Column<string>(maxLength: 100, nullable: true),
                    username = table.Column<string>(maxLength: 100, nullable: false),
                    password = table.Column<string>(maxLength: 100, nullable: false),
                    email = table.Column<string>(maxLength: 100, nullable: true),
                    user_picture_url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Major",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    major_name = table.Column<string>(maxLength: 100, nullable: true),
                    faculty_id = table.Column<long>(nullable: false),
                    major_logo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Major", x => x.id);
                    table.ForeignKey(
                        name: "FK_Major_Faculty_faculty_id",
                        column: x => x.faculty_id,
                        principalTable: "Faculty",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    major_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teacher", x => x.id);
                    table.ForeignKey(
                        name: "FK_Teacher_Major_major_id",
                        column: x => x.major_id,
                        principalTable: "Major",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherCourse",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    teacher_id = table.Column<long>(nullable: false),
                    course_id = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherCourse", x => x.id);
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TeacherCourse_Teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "Teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserReview",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(nullable: false),
                    survey_id = table.Column<long>(nullable: false),
                    semeter = table.Column<string>(maxLength: 10, nullable: true),
                    course_id = table.Column<long>(nullable: false),
                    teacher_id = table.Column<long>(nullable: false),
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
                        name: "FK_UserReview_Course_course_id",
                        column: x => x.course_id,
                        principalTable: "Course",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReview_Survey_survey_id",
                        column: x => x.survey_id,
                        principalTable: "Survey",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReview_Teacher_teacher_id",
                        column: x => x.teacher_id,
                        principalTable: "Teacher",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReview_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Major_faculty_id",
                table: "Major",
                column: "faculty_id");

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_major_id",
                table: "Teacher",
                column: "major_id");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourse_course_id",
                table: "TeacherCourse",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherCourse_teacher_id",
                table: "TeacherCourse",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_course_id",
                table: "UserReview",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_survey_id",
                table: "UserReview",
                column: "survey_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_teacher_id",
                table: "UserReview",
                column: "teacher_id");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_user_id",
                table: "UserReview",
                column: "user_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherCourse");

            migrationBuilder.DropTable(
                name: "UserReview");

            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Survey");

            migrationBuilder.DropTable(
                name: "Teacher");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Major");

            migrationBuilder.DropTable(
                name: "Faculty");
        }
    }
}
