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
    
    public class CourseController : BaseController
    {
        public CourseController(ApplicationDbContext context) : base(context) {}

        [HttpGet("courses")]
        public IActionResult GetCourses()
        {
           var courses = _db.Course.Select(
               x => new { id = x.id, coursename = x.course_name }
               ).ToList();
           return Json(courses);
        } 
    }
}
