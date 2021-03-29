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

    public class MajorController : BaseController
    {
        public MajorController(ApplicationDbContext context) : base(context) {}

        [HttpGet("majors")]
        public IActionResult GetAllMajors(long facultyId)
        {
            var majors = _db.Major.Where(x => x.faculty_id == facultyId)
                                  .Select(x => new
                                               {
                                                   MajorId = x.id,
                                                   MajorName = x.major_name
                                               });
            
            if (!majors.Any())
                return BadRequest(new { Message = "major not found" });

            return Json(majors);
        }
    }
}