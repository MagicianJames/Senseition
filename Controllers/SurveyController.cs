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

    public class SurveyController : BaseController
    {
        public SurveyController(ApplicationDbContext context) : base(context) { }

        [HttpPost("Survey")]

        public IActionResult Survey(SurveyViewModel model)
        {
            if(1 == model.answer_question1)
            {
                return Json(model.answer_question1);
            } 
            else if(2 == model.answer_question2)
            {
                return Json(model.answer_question2);
            } 
            else if(3 == model.answer_question3)
            {
                return Json(model.answer_question3);
            } 
            else if(4 == model.answer_question4)
            {
                return Json(model.answer_question4);
            } 
            else
            {
                return Json(model.answer_question5);
            }
            
        }
    }
}