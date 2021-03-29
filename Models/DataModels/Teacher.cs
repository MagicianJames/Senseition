using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class Teacher
    {
        public long id { get; set; }
        [StringLength (100)]
        public string first_name { get; set; }
        [StringLength (100)]
        public string last_name { get; set; }
        [StringLength (100)]
        public string position { get; set; }
        public string biography { get; set; }
        public DateTime birthdate { get; set; }
        public byte age { get; set; }
        public byte rate { get; set; }
        public string picture_url { get; set; }
        public long major_id { get; set; }
        [ForeignKey(nameof(major_id))]
        public virtual Major Major { get; set; }
        
    }
}