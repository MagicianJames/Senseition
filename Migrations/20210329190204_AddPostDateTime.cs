using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senseition.Migrations
{
    public partial class AddPostDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserReview_survey_id",
                table: "UserReview");

            migrationBuilder.AddColumn<DateTime>(
                name: "post_date_time",
                table: "UserReview",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_survey_id",
                table: "UserReview",
                column: "survey_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserReview_survey_id",
                table: "UserReview");

            migrationBuilder.DropColumn(
                name: "post_date_time",
                table: "UserReview");

            migrationBuilder.CreateIndex(
                name: "IX_UserReview_survey_id",
                table: "UserReview",
                column: "survey_id");
        }
    }
}
