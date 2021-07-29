using System;
using System.Collections.Generic;

#nullable disable

namespace PopIt.Models
{
    public partial class TestRule
    {
        public int Grade { get; set; }
        public string Subjectname { get; set; }
        public string Rules { get; set; }
        public int Totalmarks { get; set; }
        public double Passmarkss { get; set; }
        public int Examduration { get; set; }
        public string Status { get; set; }
    }
}
