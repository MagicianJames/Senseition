using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class Faculty
    {
        public long id { get; set; }
        [StringLength(100)]
        public string faculty_name { get; set; }
        public string faculty_full_name { get; set; }
        public string logo_url { get; set; }
    }

}