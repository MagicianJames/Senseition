using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Senseition.Models.DataModels
{
    public class Survey
    {
        public long id { get; set; }
        public byte answer_question1 { get; set; }
        public byte answer_question2 { get; set; }
        public byte answer_question3 { get; set; }
        public byte answer_question4 { get; set; }
        public byte answer_question5 { get; set; }
        public virtual UserReview UserReview { get; set; }
    }
}