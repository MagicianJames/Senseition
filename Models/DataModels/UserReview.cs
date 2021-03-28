using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class UserReview 
    {
        public long id { get; set; }
        [ForeignKey(nameof(user_id))]
        public long user_id { get; set; }
        public virtual User User { get; set; }
        [ForeignKey(nameof(survey_id))]
        public long survey_id { get; set; }
        public virtual Survey Survey { get; set; }
        [StringLength (10)]
        public string semeter { get; set; }
        [ForeignKey(nameof(course_id))]
        public long course_id { get; set; }
        public virtual Course Course { get; set; }
        [ForeignKey(nameof(teacher_id))]
        public long teacher_id { get; set; }
        public virtual Teacher Teacher { get; set; }
        public string review_message { get; set; }
        public int like_no { get; set; }
        public float average_rate { get; set; }
        [StringLength (100)]
        public string user_first_name { get; set; }
        [StringLength (100)]
        public string user_last_name { get; set; }
        [StringLength (100)]
        public string teacher_first_name { get; set; }
        [StringLength (100)]
        public string teacher_last_name { get; set;}
        public string course_name { get; set; }        
    }
}