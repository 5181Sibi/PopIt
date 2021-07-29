using System;
using System.Collections.Generic;

#nullable disable

namespace PopIt.Models
{
    public partial class AdminMapping
    {
        public int AdminId { get; set; }
        public int GradeId { get; set; }
        public int TeacherId { get; set; }
        public int SubjectId { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual TeacherDetail Teacher { get; set; }
    }
}
