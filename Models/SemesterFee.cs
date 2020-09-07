using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Models
{
    public partial class SemesterFee
    {
        public SemesterFee()
        {
            Student = new HashSet<Student>();
        }

        public int Semester { get; set; }
        public int? Fee { get; set; }

        public ICollection<Student> Student { get; set; }
    }
}
