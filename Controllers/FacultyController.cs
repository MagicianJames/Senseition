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

    public class FacultyController : BaseController
    {
        public FacultyController(ApplicationDbContext context) : base(context) { }

        [HttpGet("faculties")]
        public IActionResult GetAllFaculties()
        {
            var faculties = _db.Faculty.Select(
                x => new { id = x.id, facultyName = x.faculty_name, facultyLogo = x.logo_url }
                ).ToList();
            return Json(faculties);
        } 
    }
}

