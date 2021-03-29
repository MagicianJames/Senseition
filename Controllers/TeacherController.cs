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

        // [HttpGet("courses")]
        // public IActionResult GetAllFaculties()
        // {
        //     var faculties = _db.Cours.Select(x => new
        //                                             {
        //                                                 id = x.id,
        //                                                 name = x.faculty_name
        //                                             })
        //                                .ToList();
        //     return Json(faculties);
        // }
    }
}

