using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Senseition.Datas;
using Senseition.Models;
using Senseition.Models.DataModels;

namespace Senseition.Controllers
{
    [Route(_baseUrl + "[controller]")]
    [ApiController]

    public class TeacherController : BaseController
    {
        public TeacherController(ApplicationDbContext context) : base(context) { }

        [HttpGet("courses")]
        public IActionResult GetCourses(long teacherId)
        {
            var courses = _db.TeacherCourse.Include(x => x.Course)
                                           .Where(x => x.teacher_id == teacherId)
                                           .Select(x => new
                                                        {
                                                            CourseId = x.course_id,
                                                            CourseName = x.Course.course_name,

                                                        });
            
            if (!courses.Any())
                return BadRequest(new { Message = "course not found"});

            return Json(courses);
        }
    }
}