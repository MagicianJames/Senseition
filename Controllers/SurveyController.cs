using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Senseition.Datas;
using Senseition.Models;
using Senseition.Models.DataModels;

namespace Senseition.Controllers
{
    [Route(_baseUrl + "[controller]")]
    [ApiController]

    public class SurveyController : BaseController
    {
        public SurveyController(ApplicationDbContext context) : base(context) { }

        [HttpPost("Survey")]

        public async Task<IActionResult> Survey(SurveyViewModel model)
        {
            try
            {
                var survey = new Survey
                                {
                                    answer_question1 = model.AnswerQuestion1,
                                    answer_question2 = model.AnswerQuestion2,
                                    answer_question3 = model.AnswerQuestion3,
                                    answer_question4 = model.AnswerQuestion4,
                                    answer_question5 = model.AnswerQuestion5
                                };
                
                var user = _db.Users.Find(model.UserId);
                var teacher = _db.Teacher.Find(model.TeacherId);

                var userReview = new UserReview
                                    {
                                        user_id = model.UserId,
                                        semeter = "2",
                                        course_id = model.CourseId,
                                        teacher_id = model.TeacherId,
                                        review_message = model.ReviewMessage,
                                        like_no = 0,
                                        average_rate = (model.AnswerQuestion1 + model.AnswerQuestion2 + model.AnswerQuestion3 
                                                        + model.AnswerQuestion4 + model.AnswerQuestion5) / 5,
                                        user_first_name = user.first_name,
                                        user_last_name = user.last_name,
                                        teacher_first_name = teacher.first_name,
                                        teacher_last_name = teacher.last_name,
                                        course_name = _db.Course.Find(model.CourseId).course_name,
                                        post_date_time = DateTime.UtcNow
                                    };
                
                survey.UserReview = userReview;
                _db.Survey.Add(survey);
                await _db.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}