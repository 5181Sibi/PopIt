using System;
using System.Collections.Generic;

#nullable disable

namespace PopIt.Models
{
    public partial class ClassroomStudent
    {
        public ClassroomStudent()
        {
            TestDetails = new HashSet<TestDetail>();
        }

        public int Stdid { get; set; }
        public int AdminId { get; set; }
        public int StudentId { get; set; }

        public virtual ICollection<TestDetail> TestDetails { get; set; }
    }
}
