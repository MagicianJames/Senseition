using System;

namespace Senseition.Models
{
    public class SurveyViewModel
    {
        public byte AnswerQuestion1 { get; set; }
        public byte AnswerQuestion2 { get; set; }
        public byte AnswerQuestion3 { get; set; }
        public byte AnswerQuestion4 { get; set; }
        public byte AnswerQuestion5 { get; set; }
        public long UserId { get; set; }
        public long CourseId { get; set; }
        public long TeacherId { get; set; }
        public string ReviewMessage { get; set; }
    }
}