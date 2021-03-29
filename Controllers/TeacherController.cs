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

        [HttpGet("biography")]
        public IActionResult GetBiographies(long teacherId)
        {
            var teacher = _db.Teacher
                             .Include(x => x.Major)
                                .ThenInclude(x => x.Faculty)
                             .SingleOrDefault(x => x.id == teacherId);

            if (teacher == null)
                return BadRequest(new { Message = "teacher not found" });

            return Json(new
                        {
                            FullName = teacher.teacher_full_name,
                            Position = teacher.position,
                            FacultyLogo = teacher?.Major?.Faculty?.logo_url,
                            Major = teacher?.Major?.major_name,
                            Faculty = teacher?.Major?.Faculty?.faculty_name,
                            Biography = teacher.biography,
                            PictureUrl = teacher.picture_url
                        });
        }

        [HttpGet("courses")]
        public IActionResult GetCourses(long teacherId)
        {
            var courses = _db.TeacherCourse.Include(x => x.Course)
                                           .Where(x => x.teacher_id == teacherId)
                                           .Select(x => new
                                                        {
                                                            CourseId = x.course_id,
                                                            CourseName = x.Course.course_name,
                                                            Rate = (_db.UserReview.Where(y => y.course_id == x.course_id
                                                                                             && y.teacher_id == x.teacher_id)
                                                                                 .Sum(x => x.average_rate)) / 
                                                                                 
                                                                                    _db.UserReview.Where(y => y.course_id == x.course_id
                                                                                                              && y.teacher_id == x.teacher_id)
                                                                                       .Count(),
                                                            MaxRate = 5
                                                        })
                                           .OrderByDescending(x => x.Rate)
                                           .ToList();
            
            if (!courses.Any())
                return BadRequest(new { Message = "course not found"});

            return Json(courses);
        }
    }
}