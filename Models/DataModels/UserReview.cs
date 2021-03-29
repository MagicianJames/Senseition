using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class UserReview
    {
        public long id { get; set; }

        public long user_id { get; set; }
        [ForeignKey(nameof(user_id))]
        public virtual Users User { get; set; }

        public long survey_id { get; set; }
        [ForeignKey(nameof(survey_id))]
        public virtual Survey Survey { get; set; }
        [StringLength(10)]
        public string semeter { get; set; }

        public long course_id { get; set; }
        [ForeignKey(nameof(course_id))]
        public virtual Course Course { get; set; }

        public long teacher_id { get; set; }
        [ForeignKey(nameof(teacher_id))]
        public virtual Teacher Teacher { get; set; }
        public string review_message { get; set; }
        public int like_no { get; set; }
        public float average_rate { get; set; }
        [StringLength(100)]
        public string user_first_name { get; set; }
        [StringLength(100)]
        public string user_last_name { get; set; }
        [StringLength(100)]
        public string teacher_first_name { get; set; }
        [StringLength(100)]
        public string teacher_last_name { get; set; }
        public string course_name { get; set; }
        public DateTime post_date_time { get; set; }
    }
}