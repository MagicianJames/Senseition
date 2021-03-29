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

    public class FacultyController : BaseController
    {
        public FacultyController(ApplicationDbContext context) : base(context) { }

        [HttpGet("faculties")]
        public IActionResult GetAllFaculties()
        {
            var faculties = _db.Faculty.Select(x => new
                                                    {
                                                        id = x.id,
                                                        name = x.faculty_name
                                                    })
                                       .ToList();
            return Json(faculties);
        }

        [HttpGet("faculties-member")]
        public IActionResult GetAllFacultyMembers(long facultyId, int page=1, int pageSize=6)
        {
            var numPages = _db.Teacher.Include(x => x.Major)
                                      .Where(x => x.Major.facult_id == facultyId)
                                      .Count();

            var facultyMembers = _db.Teacher.Include(x => x.Major)
                                            .Where(x => x.Major.facult_id == facultyId)
                                            .Select(x => new
                                                         {
                                                             Id = x.id,
                                                             FirstName = x.first_name,
                                                             LastName = x.last_name,
                                                             Major = x.Major.major_name,
                                                             Position = x.position,
                                                             Rate = x.rate
                                                         })
                                            .Skip(pageSize * (page - 1))
                                            .Take(pageSize)
                                            .ToList();

            if (!facultyMembers.Any())
                return BadRequest(new { Message = "member not found" });

            return Json(new { members = facultyMembers, numPages });
        }

        [HttpGet("faculties-member-major")]
        public IActionResult GetAllFacultyMembersByMajor(long majorId, int page=1, int pageSize=6)
        {
            var numPages = _db.Teacher.Where(x => x.major_id == majorId)
                                      .Count();

            var facultyMembers = _db.Teacher.Include(x => x.Major)
                                            .Where(x => x.major_id == majorId)
                                            .Select(x => new
                                                         {
                                                             Id = x.id,
                                                             FirstName = x.first_name,
                                                             LastName = x.last_name,
                                                             Major = x.Major.major_name,
                                                             Position = x.position,
                                                             Rate = x.rate
                                                         })
                                            .Skip(pageSize * (page - 1))
                                            .Take(pageSize)
                                            .ToList();

            if (!facultyMembers.Any())
                return BadRequest(new { Message = "member not found" });

            return Json(new { members = facultyMembers, numPages });
        }
    }
}

