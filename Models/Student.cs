using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Models
{
    public partial class Student
    {
        public string StudentName { get; set; }
        public string EnrollmentNo { get; set; }
        public int Age { get; set; }
        public string Branch { get; set; }
        public int? Semester { get; set; }

        public SemesterFee SemesterNavigation { get; set; }
    }
}
