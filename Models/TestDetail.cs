using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class TestDetail
    {
        public TestDetail()
        {
            Questions = new HashSet<Question>();
            Results = new HashSet<Result>();
        }

        public int ExamId { get; set; }
        public string Examname { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual ClassroomStudent GradeNavigation { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Result> Results { get; set; }
    }
}
