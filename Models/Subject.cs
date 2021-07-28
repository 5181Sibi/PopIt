using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Subject
    {
        public Subject()
        {
            AdminMappings = new HashSet<AdminMapping>();
            Questions = new HashSet<Question>();
            Results = new HashSet<Result>();
            TestDetails = new HashSet<TestDetail>();
        }

        public int SubjectId { get; set; }
        public int TeacherId { get; set; }
        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual TeacherDetail Teacher { get; set; }
        public virtual ICollection<AdminMapping> AdminMappings { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<Result> Results { get; set; }
        public virtual ICollection<TestDetail> TestDetails { get; set; }
    }
}
