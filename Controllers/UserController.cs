using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
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

        [HttpPost("login")]
        public IActionResult Login(LoginViewModel model)
        {
            var user = _db.Users.SingleOrDefault(x => x.username == model.Username
                                                     && x.password == model.Password);

            if (user == null)
                return BadRequest(new { Message = "user not found" });

            return Json(new
            {
                Id = user.id,
                FirstName = user.first_name,
                LastName = user.last_name,
                Email = user.email
            });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            try
            {
                if (_db.Users.Any(x => x.username == model.Username))
                    return BadRequest(new { Message = "duplicated username!"});

                bool isValidEmail = Regex.IsMatch(model.Email,
                        @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                        RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));

                if (!isValidEmail)
                    return BadRequest(new { Message = "wrong email!" });

                var newUser = new Users()
                            {
                                first_name = model.FirstName,
                                last_name = model.LastName,
                                username = model.Username,
                                password = model.Password,
                                email = model.Email,
                            };
                
                _db.Users.Add(newUser);
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
