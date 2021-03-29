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
        public IActionResult GetMajor()
        {
            var majors = _db.Major.Include( x => x.Faculty )
            .ToList();
            return Json(majors);
        }
    }
}