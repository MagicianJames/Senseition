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
    // default if no route : website/Controllername/functionname?parameter
    // if add this line : website/api/v1/user
    [Route(_baseUrl + "[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        public UserController(ApplicationDbContext context) : base(context) { }

        // website/api/v1/user/users
        // Include : join
        // get all users
        [HttpGet("users")]
        public IActionResult GetUsers1()
        {
            var a = new User();
            return Json(a);
        }

        // website/api/v1/user/users1?user=1
        [HttpGet("users1")]
        public IActionResult GetUsers2(long user)
        {
            var a = new User();
            return Json(a);
        }

        // website/api/v1/user/users/1
        [HttpGet("users/{user}")]
        public IActionResult GetUsers(long id)
        {
            var user = new User();
            
            if(id != user.id)
            {
                return BadRequest();
            } else 
            {
                return Json(user);
            }

        }
    
        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            return Json(model);
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterViewModel model)
        {
            return Json(model);
        }


        // [HttpGet("students")]
        // public IActionResult GetStudents()
        // {
        //     var result = _studentProvider.GetStudents().ToAPIResponse();
        //     return StatusCode(result.HTTPStatusCode, result);
        // }

        // [HttpPost("students")]
        // public async Task<IActionResult> AddStudents(StudentViewModel model)
        // {
        //     var result = (await _studentProvider.AddStudents(model)).ToAPIResponse();
        //     return StatusCode(result.HTTPStatusCode, result);
        // }
    }
}
