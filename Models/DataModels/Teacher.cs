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
        public float rate { get; set; }
        public string picture_url { get; set; }
        public long major_id { get; set; }
        [ForeignKey(nameof(major_id))]
        public virtual Major Major { get; set; }

        [NotMapped]
        public string teacher_full_name
        {
            get
            {
                return $"{ first_name } { last_name }";
            }
        }
        
    }
}