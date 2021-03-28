using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class TeacherCourse 
    {
        public long id { get; set; }
        [ForeignKey(nameof(teacher_id))]
        public long teacher_id { get; set; }
        public virtual Teacher Teacher { get; set;}
        [ForeignKey(nameof(course_id))]
        public long course_id { get; set; }
        public virtual Course Course { get; set;}
    }
}
