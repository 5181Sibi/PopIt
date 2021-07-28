using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication1.Models
{
    public partial class Grade
    {
        public Grade()
        {
            AdminMappings = new HashSet<AdminMapping>();
            Subjects = new HashSet<Subject>();
            TestDetails = new HashSet<TestDetail>();
        }

        public int GradeId { get; set; }
        public string GradeName { get; set; }
        public int StudentId { get; set; }

        public virtual StudentDetail Student { get; set; }
        public virtual ICollection<AdminMapping> AdminMappings { get; set; }
        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<TestDetail> TestDetails { get; set; }
    }
}
