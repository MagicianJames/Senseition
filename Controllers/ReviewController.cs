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

    public class ReviewController : BaseController
    {
        public ReviewController(ApplicationDbContext context) : base(context) { }

        [HttpGet("top-reviews")]
        public IActionResult GetTopReview(long teacherId, long courseId, int pageSize=2)
        {
            var topReviews = _db.UserReview
                                .Include(x => x.User)
                                .Where(x => x.teacher_id == teacherId
                                            && (courseId == 0 ? true : x.course_id == courseId))
                                .OrderByDescending(x => x.like_no)
                                    .ThenByDescending(x => x.post_date_time)
                                .Take(pageSize)
                                .Select(x => new
                                             {
                                                 ReviewId = x.id,
                                                 Rate = x.average_rate,
                                                 MaxRate = 5,
                                                 UserFullName = x.User.user_full_name,
                                                 UserPictureUrl = x.User.user_picture_url,
                                                 Comment = x.review_message,
                                                 LikeNum = x.like_no
                                             })
                                .ToList();
            
            if (!topReviews.Any())
                return BadRequest(new { Message = "reviews not found!"});

            return Json(topReviews);
        }

        [HttpGet("reviews")]
        public IActionResult GetReviews(long teacherId, long courseId, int pageSize=3, int page=1)
        {
            var numPages = _db.UserReview.Where(x => courseId == 0 ? true : x.course_id == courseId)
                                         .Count();

            var topReviews = _db.UserReview
                                .Include(x => x.User)
                                .Where(x => x.teacher_id == teacherId
                                            && (courseId == 0 ? true : x.course_id == courseId))
                                .OrderByDescending(x => x.post_date_time)
                                .Skip(pageSize * (page - 1))
                                .Take(pageSize)
                                .Select(x => new
                                             {
                                                 ReviewId = x.id,
                                                 Rate = x.average_rate,
                                                 MaxRate = 5,
                                                 UserName = x.User.user_full_name,
                                                 UserPictureUrl = x.User.user_picture_url,
                                                 Comment = x.review_message,
                                                 LikeNum = x.like_no
                                             })
                                .ToList();
            
            if (!topReviews.Any())
                return BadRequest(new { Message = "reviews not found!"});

            return Json(new { topReviews, numPages });
        }

        [HttpPost("like-reviews")]
        public async Task<IActionResult> LikeReviews(long userReviewId)
        {
            try
            {
                var userReview = _db.UserReview.Find(userReviewId);
                userReview.like_no++;
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

