using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class Course
    {
        public long id { get; set; }
        [StringLength(100)]
        public string course_name { get; set; }
        [StringLength(100)]
        public string course_code { get; set; }
    }
}