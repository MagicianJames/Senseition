using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class Major
    {
        public long id { get; set; }
        [StringLength (100)]
        public string major_name { get; set; }
        public long faculty_id { get; set; }
        public string major_logo { get; set; }
        [ForeignKey(nameof(faculty_id))]
        public virtual Faculty Faculty { get; set; }
        
        
    }
}