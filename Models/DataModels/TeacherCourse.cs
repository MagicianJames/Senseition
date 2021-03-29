using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class TeacherCourse
    {
        public long id { get; set; }

        public long teacher_id { get; set; }
        [ForeignKey(nameof(teacher_id))]
        public virtual Teacher Teacher { get; set; }

        public long course_id { get; set; }
        [ForeignKey(nameof(course_id))]
        public virtual Course Course { get; set; }
    }
}
