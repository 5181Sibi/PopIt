using System;
using System.Collections.Generic;

#nullable disable

namespace PopIt.Models
{
    public partial class Question
    {
        public int QuestionNumber { get; set; }
        public int? ExamId { get; set; }
        public int? SubjectId { get; set; }
        public string Question1 { get; set; }
        public string Uploads { get; set; }
        public string Option1 { get; set; }
        public string Option2 { get; set; }
        public string Option3 { get; set; }
        public string Option4 { get; set; }
        public int Answer { get; set; }
        public string Description { get; set; }
        public double Mark { get; set; }

        public virtual TestDetail Exam { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
